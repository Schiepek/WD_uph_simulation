using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPH_Simulation_Model
{
    public class AssemblyLineValidator
    {
        public void Validate(AssemblyLine assemblyLine)
        {
            new PositionValidator().Check(assemblyLine);
            new AssemblyLineItemValidator().Check(assemblyLine);
        }

    }
}
