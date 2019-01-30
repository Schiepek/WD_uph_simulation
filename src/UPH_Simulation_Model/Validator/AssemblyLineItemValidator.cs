using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPH_Simulation_Model
{
    public class AssemblyLineItemValidator
    {
        public void Check(AssemblyLine assemblyLine)
        {
            int autostackerCounter = 0;
            foreach (AssemblyLineItem item in assemblyLine.Items)
            {
                if (item is Autostacker)
                {
                    autostackerCounter++;
                    Autostacker autostacker = (Autostacker)item;
                    if (autostacker.Positions.Any())
                    {
                        CheckFirstPosition(autostacker);
                        CheckCapacity(autostacker);
                        CheckAutostackerPositions(autostacker);
                    } else
                    {
                        string message = "An autostacker cannot be empty";
                        throw new AssemblyLineException(message);
                    }
                }
            }
            CheckAutostackerCounter(autostackerCounter);
        }

        private void CheckAutostackerPositions(Autostacker autostacker)
        {
            int dualZoneCounter = 0;
            foreach(Position position in autostacker.Positions)
            {
                if(position is DualZone)
                {
                    dualZoneCounter++;
                }
            }
            if (dualZoneCounter < UphConfig.MinDualZonesPerAutostacker)
            {
                string message = "An autostacker has to have minimum " + UphConfig.MinDualZonesPerAutostacker + " dualzones";
                throw new AssemblyLineException(message);
            }
        }

        private void CheckCapacity(Autostacker autostacker)
        {
            if (autostacker.Capacity < UphConfig.MinCapacityAutostacker)
            {
                string message = "Minimum autostacker capacity is " + UphConfig.MinCapacityAutostacker;
                throw new AssemblyLineException(message);
            }
        }

        private void CheckFirstPosition(Autostacker autostacker)
        {
            if (!(autostacker.Positions.First<Position>() is DualZone))
            {
                string message = "First position of Autostacker has to be a dualzone";
                throw new AssemblyLineException(message);
            }
        }

        private void CheckAutostackerCounter(int autostackerCounter)
        {
            if (autostackerCounter > 2)
            {
                string message = "The logic for more than 2 autostackers is not implemented";
                throw new AssemblyLineException(message);
            }
        }
    }
}
