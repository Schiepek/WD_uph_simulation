using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPH_Simulation_Model
{
    public interface IUnitHandler
    {
        void TryToGoToNextPosition(Unit unit, double currentTime, bool allUnitsInLine);
    }
}
