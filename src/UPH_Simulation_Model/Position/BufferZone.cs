using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPH_Simulation_Model
{
    public class BufferZone : Position
    {
        public BufferZone() : base()
        {
        }

        public BufferZone(int localNumber, int globalNumber, string name, Position nextPosition, double time)
            : base(localNumber, globalNumber, name, nextPosition, time)
        {
            UnitHandler = new UnitBufferHandler();
        }

        public BufferZone(int localNumber, string name, double time)
    : base(localNumber, name, time)
        {
            UnitHandler = new UnitBufferHandler();
        }

    }
}
