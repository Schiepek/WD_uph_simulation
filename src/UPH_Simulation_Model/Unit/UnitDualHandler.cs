using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPH_Simulation_Model
{
    public class UnitDualHandler : UnitHandler
    {
        protected override void GoToNextPositionOrWait(Unit unit, double currentTime, bool allUnitsInLine)
        {
            DualZone currentPosition = (DualZone)unit.CurrentPosition;
            DualZone nextDualZone = currentPosition.GetNextDualZone();
            DualZone currentDualZone = (DualZone)unit.CurrentPosition;
            Position nextZone = unit.CurrentPosition.GetNextZone();

            if (IsInAutostacker(currentPosition, nextZone))
            {
                HandleAutoStacker(unit, currentTime, currentPosition, currentDualZone);
            }
            else if (NextDualZoneIsAvailable(nextDualZone, currentDualZone, nextZone))
            {
                HandleStartDualZone(unit, currentTime, currentDualZone);
            }
            else if (!nextZone.IsActive() && !nextPosition.IsActive())
            {
                HandleEndDualZone(unit, currentTime);
            }
            else
            {
                unit.CurrentPosition.IncreaseTime();
            }
        }

        private bool NextDualZoneIsAvailable(DualZone nextDualZone, DualZone currentDualZone, Position nextZone)
        {
            return  nextDualZone != null
                    && currentDualZone.Operation.Equals(nextDualZone.Operation, StringComparison.OrdinalIgnoreCase)
                    && !nextZone.IsActive();

        }

        private bool IsInAutostacker(DualZone currentPosition, Position nextZone)
        {
            return currentPosition.ParentItem is Autostacker && !nextZone.IsActive();
        }

        private void HandleEndDualZone(Unit unit, double currentTime)
        {
            unit.TerminateComponentMount();
            unit.GoToNextPosition(currentTime);
        }

        private void HandleStartDualZone(Unit unit, double currentTime, DualZone currentDualZone)
        {
            if (currentDualZone.IsWorking())
            {
                unit.MountComponent();
            }
            unit.GoToNextPosition(currentTime);
        }

        private void HandleAutoStacker(Unit unit, double currentTime, DualZone currentPosition, DualZone currentDualZone)
        {
            Autostacker currentAutostacker = (Autostacker)currentPosition.ParentItem;

            if (currentAutostacker.IsLastAutoStackerDualZone(currentDualZone))
            {
                HandleLastAutostackerDualZone(unit, currentDualZone, currentAutostacker);
            }
            if (currentAutostacker.IsFirstAutoStackerZone(currentDualZone) && currentDualZone.IsWorking())
            {
                unit.IsInAutostacker = true;
            }
            unit.GoToNextPosition(currentTime);
        }

        private void HandleLastAutostackerDualZone(Unit unit, DualZone currentDualZone, Autostacker currentAutostacker)
        {
            if (currentDualZone.IsWorking())
            {
                unit.IsInAutostacker = false;
                if (currentAutostacker.GetNextAutostacker() != null)
                {
                    unit.MountComponent();
                }
            }
            if (currentDualZone.IsBuffering() && currentAutostacker.GetNextAutostacker() == null)
            {
                unit.TerminateComponentMount();
            }
        }
    }
}
