using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPH_Simulation_Model
{
    public class ResultCalculation
    {
        private static readonly double oneHourInSeconds = 3600.0;

        private readonly Units units;

        private readonly AssemblyLine assemblyLine;

        private Result result;

        public ResultCalculation(Units units, AssemblyLine assemblyLine)
        {
            this.units = units;
            this.assemblyLine = assemblyLine;
            this.result = new Result();
        }

        public Result Calculate()
        {
            CalculateCycleTime();
            CalculateOutToOut();
            CalculateUnitsPerHour();
            CalculateWaitingTime();
            NotifyFinishedState();
            return result;
        }

        private void CalculateCycleTime()
        {
            List<double> totalTimes = new List<double>();
            foreach (Unit unit in units.All())
            {
                totalTimes.AddRange(unit.TotalTimes);               
            }
            result.CycleTime = totalTimes.Average();
        }

        private void CalculateUnitsPerHour()
        {
            result.UnitsPerHour = oneHourInSeconds / result.OutToOut;
        }

        private void CalculateOutToOut()
        {
            AssemblyLineItem lastItem = assemblyLine.GetLastWorkingItem();
            List<double> outToOutValues = lastItem.OutToOuts;

            result.OutToOut = outToOutValues.Average<double>(d => d);
            result.AutoOutRange = outToOutValues.Max<double>() - outToOutValues.Min<double>();
        }

        private void CalculateWaitingTime()
        {
            double rounds = Convert.ToDouble(UphConfig.NumberOfRounds - 1);         

            foreach (Position position in assemblyLine.GetPositions())
            {
                position.AverageWaitingTime = position.TotalWaitingTime / rounds / assemblyLine.NumberOfUnits;
            }

            List<Position> rankList = assemblyLine.GetPositions().OrderByDescending(p => p.TotalWaitingTime).ToList();

            int rank = 1;
            foreach(Position position in rankList)
            {
                if(!(position is TransferPosition))
                {
                    position.Rank = rank;
                    rank++;
                }
            }
        }

        private void NotifyFinishedState()
        {
            assemblyLine.GetPositions().ForEach((p) => p.NotifyPropertyChanged("State"));
        }
    }
}
