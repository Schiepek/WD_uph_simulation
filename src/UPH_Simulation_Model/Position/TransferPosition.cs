using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPH_Simulation_Model
{
    public class TransferPosition : Position
    {
        public TransferPosition() : base()
        {
            UnitHandler = new UnitTransferHandler();
        }

        public TransferPosition(int localNumber, int globalNumber, String name, Position nextPosition, double time)
            : base(localNumber, globalNumber, name, nextPosition, time)
        {
            UnitHandler = new UnitTransferHandler();
        }

        public TransferPosition(int localNumber, string name, double time)
    : base(localNumber, name, time)
        {
            UnitHandler = new UnitTransferHandler();
        }

        public override Position GetNextZone()
        {
            if (NextPosition is TransferPosition)
            {
                string message = "The next zone after a transfer cannot be a transfer";
                throw new PositionOrderException(message);
            }
            return NextPosition;
        }

   }
}
