using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPH_Simulation_Model
{
    public class UnitTransferHandler : UnitHandler
    {
        protected override void GoToNextPositionOrWait(Unit unit, double currentTime, bool allUnitsInLine)
        {
            if (!nextPosition.IsActive())
            {
                unit.GoToNextPosition(currentTime);
            }
            else
            {
                unit.CurrentPosition.IncreaseTime();
            }
        }
    }
}
