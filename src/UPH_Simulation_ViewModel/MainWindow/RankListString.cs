using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPH_Simulation_Model;

namespace UPH_Simulation_ViewModel
{
    class RankListString
    {
        private ObservableCollection<PositionVM> positionVMs;

        public RankListString(ObservableCollection<PositionVM> positionVMs)
        {
            this.positionVMs = positionVMs;
        }

        public String Create(Result result)
        {
            if (!UphMathUtil.IsEqualTo(result.OutToOut, 0.0))
            {
                return createRankListString();
            }
            else
            {
                return "You have to calculate first";
            }
        }

        private String createRankListString()
        {
            StringBuilder sb = new StringBuilder();
            List<PositionVM> rankList = createRankList();

            if (rankList.Any())
            {
                foreach (PositionVM positionVM in rankList)
                {
                    sb.Append(positionVM.Rank + ".   ");
                    String waitingTime = Convert.ToString(Math.Round(positionVM.WaitingTime, 2));
                    sb.Append(waitingTime.PadRight(7));
                    sb.Append(positionVM.Name + " (");
                    sb.Append(PositionTypeExtensions.ToString(positionVM.Type) + ") ");
                    sb.AppendLine(positionVM.position.ParentItem.Name);
                }
            }
            else
            {
                sb.Append("No waiting times in this line");
            }
            return sb.ToString();
        }

        private List<PositionVM> createRankList()
        {
            List<PositionVM> tempList = new List<PositionVM>();

            foreach (PositionVM positionVM in positionVMs)
            {
                if (!UphMathUtil.IsEqualTo(positionVM.WaitingTime, 0.0) && positionVM.Type != PositionTypeVM.TRANSFER)
                {
                    tempList.Add(positionVM);
                }
            }
            return tempList.OrderByDescending<PositionVM, double>((p) => p.WaitingTime).ToList<PositionVM>();
        }
    }
}
