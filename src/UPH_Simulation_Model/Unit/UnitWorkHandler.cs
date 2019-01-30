using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPH_Simulation_Model
{
    public class UnitWorkHandler : UnitHandler
    {
        protected override void GoToNextPositionOrWait(Unit unit, double currentTime, bool allUnitsInLine)
        {
            if (!unit.CurrentPosition.GetNextZone().IsActive() && !nextPosition.IsActive())
            {
                if (unit.CurrentPosition.NextPosition.IsLastPosition)
                {
                    if (allUnitsInLine)
                    {
                        unit.GoToNextPosition(currentTime);
                    }
                    else
                    {
                        unit.CurrentPosition.IncreaseTime();
                    }
                }
                else
                {
                    unit.GoToNextPosition(currentTime);
                }
            }
            else
            {
                unit.CurrentPosition.IncreaseTime();
            }
        }
    }
}
