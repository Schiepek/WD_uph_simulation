using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPH_Simulation_Model
{
    public class PositionValidator
    {
        public void Check(AssemblyLine assemblyLine)
        {
            List<Position> positions = assemblyLine.GetPositions();
            if (positions.Any())
            {
                CheckLastZone(positions);
                CheckZoneTransferAlternation(positions);
                CheckNumberOfUnitsInLine(assemblyLine);
            }
            else
            {
                throw new AssemblyLineException("The assemblyline is empty!");
            }
        }

        private void CheckLastZone(List<Position> positions)
        {
            if (UphUtil.IsZone(positions.Last<Position>()))
            {
                string message = "The last position has to be a transfer (to the first position)";
                throw new AssemblyLineException(message);
            }
        }

        private void CheckZoneTransferAlternation(List<Position> positions)
        {
            foreach (Position position in positions)
            {
                Position nextPosition = position.NextPosition;

                if (UphUtil.IsZone(position) && (nextPosition != null && UphUtil.IsZone(nextPosition)))
                {
                    string message = CreateErrorMessage(position, nextPosition, "zone");
                    throw new AssemblyLineException(message);
                }
                else if (UphUtil.IsTransfer(position) && UphUtil.IsTransfer(nextPosition))
                {
                    string message = CreateErrorMessage(position, nextPosition, "transfer");
                    throw new AssemblyLineException(message);
                }
            }
        }

        private void CheckNumberOfUnitsInLine(AssemblyLine assemblyLine)
        {
            int maxPossibleUnitsInLine = assemblyLine.GetMaxPossibleUnitsInLine();
            if (assemblyLine.NumberOfUnits > maxPossibleUnitsInLine)
            {
                string message = "Too many units for this assemblyline (max " + (maxPossibleUnitsInLine) + ")";
                throw new AssemblyLineException(message);
            }
        }



        private string CreateErrorMessage(Position position, Position nextPosition, string type)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Two " + type + "s next to each other are not allowed");
            if (position.Name != "" && nextPosition.Name != "")
            {
                AddItemAndPositionInfoToErrorMessage(sb, position);
                AddItemAndPositionInfoToErrorMessage(sb, nextPosition);
            }
            return sb.ToString();
        }

        private void AddItemAndPositionInfoToErrorMessage(StringBuilder sb, Position position)
        {
            sb.Append(position.ParentItem.Name);
            sb.Append(" (nr. ");
            sb.Append(position.ParentItem.Number);
            sb.Append(")");
            sb.Append(" - ");
            sb.AppendLine(position.Name);
        }
    }
}
