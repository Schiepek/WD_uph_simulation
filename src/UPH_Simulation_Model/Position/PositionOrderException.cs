using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPH_Simulation_Model
{
    class PositionOrderException : Exception
    {
        public PositionOrderException(string message)
            : base(message)
        {
        }
    }
}
