using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UPH_Simulation_Model
{
    public abstract class Position : INotifyPropertyChanged
    {
        private readonly string initialName = "Zone";

        public String Name { get; set; }

        public PositionTime Time { get; set; }

        public Position NextPosition { get; set; }

        private Unit currentUnit;

        public Unit CurrentUnit
        {
            get { return this.currentUnit; }
            set
            {
                if (this.currentUnit != value)
                {
                    this.currentUnit = value;
                    this.NotifyPropertyChanged("CurrentUnit");
                }
            }
        }

        public virtual PositionState State
        {
            get
            {
                if(Rank != 0)
                {
                    return PositionState.FINISHED;
                } else if (Time.TimeExceeded())
                {
                    return PositionState.WAIT;
                }
                else if (Time.TimeIsRunning())
                {
                    return PositionState.BUFFER;
                }
                else
                {
                    return PositionState.FREE;
                }
            }
        }

        public double FinishedTime { get; set; }

        public bool IsFirstPosition { set; get; }

        public bool IsLastPosition
        {
            get
            {
                return NextPosition.IsFirstPosition;
            }
        }

        public AssemblyLineItem ParentItem { get; set; }

        public bool IsFirstMachineZone
        {
            get
            {
                return LocalNumber == 1;
            }
        }

        public bool IsLastMachineZone
        {
            get
            {
                if(this.NextPosition is TransferPosition)
                {
                    return NextPosition.IsLastMachinePosition();
                }
                return IsLastMachinePosition();
            }
        }

        public IUnitHandler UnitHandler { get; protected set; }

        private int localNumber;

        public int LocalNumber
        {
            get { return this.localNumber; }
            set
            {
                if (this.localNumber != value)
                {
                    this.localNumber = value;
                    this.NotifyPropertyChanged("Number");
                }
            }
        }

        public int GlobalNumber { get; set; }

        public double TotalWaitingTime { get; set; }

        private double averageWaitingTime;

        public double AverageWaitingTime
        {
            get { return this.averageWaitingTime; }
            set
            {
                if (this.averageWaitingTime != value)
                {
                    this.averageWaitingTime = value;
                    this.NotifyPropertyChanged("AverageWaitingTime");
                }
            }
        }

        private int rank;

        public int Rank
        {
            get { return this.rank; }
            set
            {
                if (this.rank != value)
                {
                    this.rank = value;
                    this.NotifyPropertyChanged("Rank");
                }
            }
        }

        public Position()
        {
            this.Time = new PositionTime(UphConfig.StandardTransferTime);
            this.Name = initialName;
        }

        public Position(int localNumber, int globalNumber, String name, Position nextPosition, double time)
        {
            this.LocalNumber = localNumber;
            this.GlobalNumber = globalNumber;
            this.Name = name;
            this.NextPosition = nextPosition;
            this.Time = new PositionTime(time);
        }

        public void FinishMachine(double currentTime, int Round)
        {
            //First Round is not valued, because the first units
            //pass through the machines without congestion
            if(UphUtil.RoundIsValid(Round))
            {
                double outToOut = currentTime - FinishedTime;
                ParentItem.OutToOuts.Add(outToOut);
            }
            FinishedTime = currentTime;
        }

        public Position(int localNumber, String name, double time)
        {
            this.LocalNumber = localNumber;
            this.Name = name;
            this.Time = new PositionTime(time);
        }

        public virtual Position GetNextZone()
        {
            Position NextZone = NextPosition.NextPosition;
            if (NextZone is TransferPosition)
            {
                string message = "The next zone cannot be a transfer";
                throw new PositionOrderException(message);
            }
            return NextZone;
        }

        public virtual bool TimeIsOver()
        {
            return Time.TimeIsOver();
        }

        public virtual void ResetForNextUnit()
        {
            Time.Reset();
            CurrentUnit = null;
        }

        public virtual bool IsActive()
        {
            return Time.IsActive();
        }

        public virtual double GetCurrentTime()
        {
            return Time.CurrentTime;
        }

        public virtual void IncreaseTime()
        {
            int Round = CurrentUnit.Round;
            if(UphUtil.RoundIsValid(Round) && State == PositionState.WAIT)
            {
                TotalWaitingTime += UphConfig.TimeStep;
            }
            Time.IncreaseTime();
        }

        public virtual void Reset()
        {
            CurrentUnit = null;
            NextPosition = null;
            FinishedTime = 0;
            TotalWaitingTime = 0.0;
            AverageWaitingTime = 0.0;
            IsFirstPosition = false;
            ParentItem = null;
            GlobalNumber = 0;
            Rank = 0;
            Time.Reset();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        private bool IsLastMachinePosition()
        {
            return ParentItem.Positions.Count == LocalNumber;
        }
    }
}
