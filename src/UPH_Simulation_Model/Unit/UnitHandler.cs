using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPH_Simulation_Model
{
    public abstract class UnitHandler : IUnitHandler
    {
        protected Position nextPosition;

        public void TryToGoToNextPosition(Unit unit, double currentTime, bool allUnitsInLine)
        {
            nextPosition = unit.GetNextPosition();
            Position nextZone = unit.CurrentPosition.GetNextZone();
            unit.IncreaseTotalTime();
            if(nextZone.ParentItem is Autostacker)
            {
                Autostacker autostacker = (Autostacker)nextZone.ParentItem;
                if(autostacker.IsFirstAutoStackerZone(nextZone) && autostacker.CapacityReached)
                {
                    unit.CurrentPosition.IncreaseTime();
                }
                else
                {
                    GoToNextPositionOrWait(unit, currentTime, allUnitsInLine);
                }
            } else
            {
                GoToNextPositionOrWait(unit, currentTime, allUnitsInLine);
            }
            
        }

        abstract protected void GoToNextPositionOrWait(Unit unit, double currentTime, bool allUnitsInLine);
    }
}
