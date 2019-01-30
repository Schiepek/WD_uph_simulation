using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPH_Simulation_Model
{
    public class DualZone : Position
    {
        private readonly string initialOperation = "Operation";

        public string Operation { get; set; }

        public PositionTime LazyTime { get; set; }

        public DualZone(int localNumber, String name, double time) : base(localNumber, name, time)
        {
            this.LazyTime = new PositionTime(UphConfig.StandardTransferTime);
            this.Operation = initialOperation;
            this.UnitHandler = new UnitDualHandler();
        }

        public DualZone(int localNumber, String name, double time, double lazyTime, string operation)
            : base(localNumber, name, time)
        {
            this.LazyTime = new PositionTime(lazyTime);
            this.Operation = operation;
            this.UnitHandler = new UnitDualHandler();
        }

        public override bool TimeIsOver()
        {
            return Time.TimeIsOver() || LazyTime.TimeIsOver();
        }

        public override void ResetForNextUnit()
        {
            Time.Reset();
            LazyTime.Reset();
            CurrentUnit = null;
        }

        public override bool IsActive()
        {
            return Time.IsActive() || LazyTime.IsActive();
        }

        public override PositionState State
        {
            get
            {
                if (Rank != 0)
                {
                    return PositionState.FINISHED;
                }
                else if (Time.TimeExceeded() || LazyTime.TimeExceeded())
                {
                    return PositionState.WAIT;
                }
                else if (Time.TimeIsRunning())
                {
                    return PositionState.WORK;
                }
                else if (LazyTime.TimeIsRunning())
                {
                    return PositionState.BUFFER;
                }
                else
                {
                    return PositionState.FREE;
                }
            }
        }

        public override double GetCurrentTime()
        {
            if (Time.IsActive())
            {
                return Time.CurrentTime;
            }
            else if (LazyTime.IsActive())
            {
                return LazyTime.CurrentTime;
            }
            return 0;
        }

        public override void IncreaseTime()
        {
            if (IsActive())
            {
                IncreaseSpecificTime();
            }
            else if (IsReadyForWork())
            {
                Time.IncreaseTime();
            }
            else
            {
                LazyTime.IncreaseTime();
            }
        }

        public bool IsWorking()
        {
            return Time.IsActive();
        }

        public bool IsBuffering()
        {
            return LazyTime.IsActive();
        }

        public bool IsReadyForWork()
        {
            DualZone nextDualZone = GetNextDualZone();
            Unit nextUnit = CurrentUnit.NextUnit;

            if (ParentItem is Autostacker)
            {
                switch (UphConfig.AutostackerMode)
                {
                    case AutostackerMode.CheckCapacity: return IsReadyForWorkStackerCheckCapacity();
                    case AutostackerMode.RoundRobin: return IsReadyForWorkStackerRoundRobin();
                    default: return IsReadyForWorkStackerRoundRobin();
                }
            }
            else
            {
                return IsReadyForWorkAssemblyLineItem();
            }
        }

        private bool IsReadyForWorkStackerRoundRobin()
        {
            if (CurrentUnit.IsInAutostacker)
            {
                return true;
            }
            else if (CurrentUnit.HasComponent)
            {
                return false;
            }
            else

            if (IsFirstMachineZone)
            {
                Autostacker currentAutostacker = (Autostacker)ParentItem;
                Autostacker nextAutostacker = currentAutostacker.GetNextAutostacker();
                if (nextAutostacker != null)
                {
                    return currentAutostacker.EvaluateRoundRobinState();
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        public override void Reset()
        {
            LazyTime.Reset();
            base.Reset();
        }

        public DualZone GetNextDualZone()
        {
            Position nextPosition = NextPosition;
            while (true)
            {
                if (nextPosition.IsLastPosition)
                {
                    return null;
                }
                else if (nextPosition is DualZone)
                {
                    DualZone nextDualZone = (DualZone)nextPosition;
                    return Operation.Equals(nextDualZone.Operation, StringComparison.OrdinalIgnoreCase) ? nextDualZone : null;
                }
                nextPosition = nextPosition.NextPosition;
            }
        }

        private bool IsReadyForWorkStackerCheckCapacity()
        {
            if (CurrentUnit.IsInAutostacker)
            {
                return true;
            }
            if (CurrentUnit.HasComponent)
            {
                return false;
            }
            Autostacker currentAutostacker = (Autostacker)ParentItem;
            Autostacker nextAutostacker = currentAutostacker.GetNextAutostacker();
            if (nextAutostacker == null || NoMoreAvailableAutostackersForUnit(nextAutostacker))
            {
                return true;
            }
            return false;
        }

        private bool IsReadyForWorkAssemblyLineItem()
        {
            DualZone nextDualZone = GetNextDualZone();
            if (nextDualZone == null)
            {
                return !CurrentUnit.HasComponent;
            }
            else if (CurrentUnit.HasComponent)
            {
                return false;
            }
            else if (nextDualZone.IsWorking() || NoMoreAvailableDualZonesForUnits())
            {
                return true;
            }
            return false;
        }

        private void IncreaseSpecificTime()
        {
            if (Time.IsActive())
            {
                Time.IncreaseTime();
            }
            else if (LazyTime.IsActive())
            {
                LazyTime.IncreaseTime();
            }
        }

        private bool NoMoreAvailableDualZonesForUnits()
        {
            int lastDualZoneInRow = GetLastDualZonesInRow();
            int numberOfAvailableDualZones = GetNextNonWorkingDualZones();
            int numberOfAvailableUnits = CurrentUnit.CountUnitsWithoutComponentBetweenDualZones(GlobalNumber, lastDualZoneInRow);
            return numberOfAvailableDualZones == numberOfAvailableUnits;
        }

        private int GetLastDualZonesInRow()
        {
            DualZone nextDualZone = GetNextDualZone();
            while (true)
            {
                if (nextDualZone.GetNextDualZone() == null)
                {
                    return nextDualZone.GlobalNumber;
                }
                nextDualZone = nextDualZone.GetNextDualZone();
            }
        }

        private int GetNextNonWorkingDualZones()
        {
            int nonWorkingPositionCount = 0;
            DualZone nextDualZone = GetNextDualZone();
            while (true)
            {
                if (nextDualZone == null)
                {
                    return nonWorkingPositionCount;
                }
                else if (!nextDualZone.IsWorking())
                {
                    nonWorkingPositionCount++;
                }
                nextDualZone = nextDualZone.GetNextDualZone();
            }
        }

        private bool NoMoreAvailableAutostackersForUnit(Autostacker nextAutostacker)
        {
            int unfinishedUnits = GetNumberOfUnfinishedUnitsIncludeNextAutoStacker(nextAutostacker);
            int capacity = nextAutostacker.Capacity;
            return unfinishedUnits >= capacity;
        }

        private int GetNumberOfUnfinishedUnitsIncludeNextAutoStacker(Autostacker nextAutostacker)
        {
            Position position = NextPosition;
            int unfinishedUnits = 0;

            List<Position> positionsToProof = new List<Position>();

            while (!position.ParentItem.Equals(nextAutostacker))
            {
                positionsToProof.Add(position);
                position = position.NextPosition;
            }
            positionsToProof.AddRange(nextAutostacker.Positions);
            if (positionsToProof.Last() is TransferPosition)
            {
                positionsToProof.Remove(positionsToProof.Last());
            }
            foreach (Position pos in positionsToProof)
            {
                if (pos.CurrentUnit != null)
                {
                    if (PositionIsCanBeCountAsUnfinished(pos))
                    {
                        unfinishedUnits++;
                    }
                }
            }
            return unfinishedUnits;
        }

        private bool PositionIsCanBeCountAsUnfinished(Position position)
        {
            bool isNotAssignedToCurrentAutostacker = position.ParentItem.Equals(ParentItem)
                                                    && !position.CurrentUnit.IsInAutostacker;
            bool hasNoComponentOutsideCurrentAutostacker = !position.CurrentUnit.HasComponent
                                                    && !position.ParentItem.Equals(ParentItem);
            return isNotAssignedToCurrentAutostacker || hasNoComponentOutsideCurrentAutostacker;
        }

    }
}
