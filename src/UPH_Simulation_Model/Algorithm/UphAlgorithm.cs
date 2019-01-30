using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UPH_Simulation_Model;

namespace UPH_Simulation_Model
{
    public class UphAlgorithm : INotifyPropertyChanged
    {
        public Units Units
        {
            get; private set;
        }

        private AssemblyLine assemblyLine;

        private double time;

        public double Time
        {
            get { return this.time; }
            set
            {
                if (this.time != value)
                {
                    this.time = value;
                    this.NotifyPropertyChanged("Time");
                }
            }
        }

        private int round;

        public int Round
        {
            get { return this.round; }
            set
            {
                if (this.round != value)
                {
                    this.round = value;
                    this.NotifyPropertyChanged("Round");
                }
            }
        }

        private Result result;
        public Result Result
        {
            get { return this.result; }
            set
            {
                if (this.result != value)
                {
                    this.result = value;
                    this.NotifyPropertyChanged("Result");
                }
            }
        }

        private int unitNumber = 1;

        public UphAlgorithm(AssemblyLine assemblyLine)
        {
            this.assemblyLine = assemblyLine;
            this.Units = new Units(assemblyLine.NumberOfUnits);
            this.Result = new Result();
        }

        public void Calculate()
        {
            while (!Units.AllUnitsAreFinished(UphConfig.NumberOfRounds))
            {
                ProceedOneTimeStep();
            }
            CalculateResult();
        }

        public void CalculateResult()
        {
            Result = new ResultCalculation(Units, assemblyLine).Calculate();
        }

        public void Reset()
        {
            Units = new Units(assemblyLine.NumberOfUnits);
            Result = new Result();
            Time = 0.0;
            unitNumber = 1;
            Round = Units.LastUnitRound;
        }

        public void ProceedOneTimeStep()
        {
            ProcessAllUnits();
            TryToAddNewUnit();
            Time += UphConfig.TimeStep;
            Round = Units.LastUnitRound;
        }

        private void TryToAddNewUnit()
        {
            Position firstPosition = assemblyLine.FirstPosition;
            Position lastPosition = assemblyLine.LastPosition;
            if (FirstPositionIsReady())
            {
                if (firstPosition.ParentItem is Autostacker)
                {
                    Autostacker autostacker = (Autostacker)firstPosition.ParentItem;
                    if (!autostacker.CapacityReached)
                    {
                        AddNewUnit();
                    }

                }
                else
                {
                    AddNewUnit();
                }
            }
        }

        private bool FirstPositionIsReady()
        {
            Position firstPosition = assemblyLine.FirstPosition;
            Position lastPosition = assemblyLine.LastPosition;

            return
                !firstPosition.IsActive() &&
                !firstPosition.NextPosition.IsActive() &&
                unitNumber <= assemblyLine.NumberOfUnits &&
                !lastPosition.IsActive();
        }

        private void AddNewUnit()
        {
            Unit unit = Units.All()[unitNumber - 1];
            unit.CurrentPosition = assemblyLine.FirstPosition;
            unit.CurrentPosition.CurrentUnit = unit;
            unit.GoToNextTimeStep(Time, Units.AllUnitsAreInLine());
            unitNumber++;
        }

        private void ProcessAllUnits()
        {
            foreach (Unit unit in Units.All())
            {
                if (unit.CurrentPosition != null)
                {
                    unit.GoToNextTimeStep(time, Units.AllUnitsAreInLine());
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
