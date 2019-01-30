using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPH_Simulation_Model
{
    public class Unit : INotifyPropertyChanged
    {
        public Position CurrentPosition { get; set; }

        public Unit NextUnit { get; set; }

        public double TotalTime { get; private set; }

        public List<double> TotalTimes { get; private set; }

        public double FinishedTime { get; private set; }

        public int Number { get; private set; }

        private bool hasComponent;

        public bool HasComponent
        {
            get { return this.hasComponent; }
            set
            {
                if (this.hasComponent != value)
                {
                    this.hasComponent = value;
                    this.NotifyPropertyChanged("HasComponent");
                }
            }
        }

        private bool isInAutostacker;

        public bool IsInAutostacker
        {
            get { return this.isInAutostacker; }
            set
            {
                if (this.isInAutostacker != value)
                {
                    this.isInAutostacker = value;
                    this.NotifyPropertyChanged("IsInAutostacker");
                }
            }
        }

        public int Round { get; set; }

        public Unit(int number)
        {
            this.Number = number;
            this.TotalTimes = new List<double>();
        }

        public Position GetNextPosition()
        {
            return CurrentPosition.NextPosition;
        }

        public void GoToNextTimeStep(double currentTime, bool allUnitsInLine)
        {
            if (CurrentPosition.TimeIsOver())
            {
                IUnitHandler unitHandler = CurrentPosition.UnitHandler;
                unitHandler.TryToGoToNextPosition(this, currentTime, allUnitsInLine);
            }
            else
            {
                IncreaseTotalTime();
                CurrentPosition.IncreaseTime();
            }
        }

        public void GoToNextPosition(double currentTime)
        {
            if (CurrentPosition.IsLastMachineZone)
            {
                CurrentPosition.FinishMachine(currentTime, Round);
            }
            if (CurrentPosition.IsLastPosition)
            {
                if (Round != 0)
                {
                    TotalTimes.Add(TotalTime);
                }
                TotalTime = 0.0;
                Round++;
            }
            CurrentPosition.ParentItem.CalculateOutToOut();
            CurrentPosition.ResetForNextUnit();
            CurrentPosition = CurrentPosition.NextPosition;
            CurrentPosition.CurrentUnit = this;
            CurrentPosition.IncreaseTime();
        }

        public void IncreaseTotalTime()
        {
                TotalTime += UphConfig.TimeStep;
        }

        public int CountUnitsWithoutComponentBetweenDualZones(int start, int end)
        {
            int unitCounter = 0;
            Unit nextUnit = this.NextUnit;
            while (true)
            {
                if (nextUnit == null || nextUnit.IsFinished())
                {
                    return unitCounter;
                }
                else if (UphMathUtil.IsBetween(nextUnit.CurrentPosition.GlobalNumber, start, end))
                {
                    if (nextUnit.CurrentPosition != null && !nextUnit.HasComponent)
                    {
                        unitCounter++;
                    }
                }
                else
                {
                    return unitCounter;
                }
                nextUnit = nextUnit.NextUnit;
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

        public void MountComponent()
        {
            HasComponent = true;
        }

        public void TerminateComponentMount()
        {
            HasComponent = false;
        }

        public bool IsFinished()
        {
            return CurrentPosition == null;
        }

    }
}
