using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPH_Simulation_Model
{
    public class AssemblyLineInitiator
    {
        public void Execute(AssemblyLine assemblyLine)
        {
            int globalPositionNumber = 1;
            Position oldPosition = null;
            Position firstPosition = null;
            foreach (AssemblyLineItem item in assemblyLine.Items) 
            {
                foreach(Position position in item.Positions)
                {
                    position.ParentItem = item;
                    if(oldPosition != null)
                    {
                        oldPosition.NextPosition = position;
                    } else
                    {
                        position.IsFirstPosition = true;
                        firstPosition = position;                        
                    }
                    position.GlobalNumber = globalPositionNumber;
                    globalPositionNumber++;
                    oldPosition = position;
                }
            }
            if(oldPosition != null)
            {
                oldPosition.NextPosition = firstPosition;
            }
            
        }
    }
}
