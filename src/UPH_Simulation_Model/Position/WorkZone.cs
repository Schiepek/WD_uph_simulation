using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPH_Simulation_Model
{
    public class WorkZone : Position
    {
        public override PositionState State
        {
            get
            {
                if (Rank != 0)
                {
                    return PositionState.FINISHED;
                }
                else if (Time.TimeExceeded())
                {
                    return PositionState.WAIT;
                }
                else if (Time.TimeIsRunning())
                {
                    return PositionState.WORK;
                }
                else
                {
                    return PositionState.FREE;
                }
            }
        }

        public WorkZone() : base()
        {
            UnitHandler = new UnitWorkHandler();
        }

        public WorkZone(int localNumber, int globalNumber, String name, Position nextPosition, double time)
            : base(localNumber, globalNumber, name, nextPosition, time)
        {
            UnitHandler = new UnitWorkHandler();
        }

        public WorkZone(int localNumber, string name, double time)
            : base(localNumber, name, time)
        {
            UnitHandler = new UnitWorkHandler();
        }

    }
}
