using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPH_Simulation_Model;

namespace UPH_Simulation_ViewModel
{
    public class ResultVM : ViewModelBase
    {
        private Result result;

        public Result Result
        {
            get { return this.result; }
            set
            {
                if (this.result != value)
                {
                    this.result = value;
                    base.OnPropertyChanged("Result");
                }
            }
        }

        public ObservableCollection<PositionVM> WaitingRankList    {  get; set;   }

        private double cycleTime;

        public double CycleTime
        {
            get { return this.cycleTime; }
            set
            {
                if (this.cycleTime != value)
                {
                    this.cycleTime = value;
                    base.OnPropertyChanged("CycleTime");
                }
            }
        }

        private double autoOut;

        public double AutoOut
        {
            get { return this.autoOut; }
            set
            {
                if (this.autoOut != value)
                {
                    this.autoOut = value;
                    base.OnPropertyChanged("AutoOut");
                }
            }
        }

        private double unitsPerHour;

        public double UnitsPerHour
        {
            get { return this.unitsPerHour; }
            set
            {
                if (this.unitsPerHour != value)
                {
                    this.unitsPerHour = value;
                    base.OnPropertyChanged("UnitsPerHour");
                }
            }
        }

        private double autoOutRange;

        public double AutoOutRange
        {
            get { return this.autoOutRange; }
            set
            {
                if (this.autoOutRange != value)
                {
                    this.autoOutRange = value;
                    base.OnPropertyChanged("AutoOutRange");
                }
            }
        }

        private ObservableCollection<AssemblyLineItemVM> ItemVMs;

        public ResultVM(ObservableCollection<AssemblyLineItemVM> ItemVMs)
        {
            this.Result = new Result();
            this.PropertyChanged += HandlePropertyChanged;
            this.ItemVMs = ItemVMs;
        }

        private void HandlePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "Result":
                    UpdateProperties();
                    break;
            }
        }

        private void UpdateProperties()
        {
            CycleTime = result.CycleTime;
            AutoOut = result.OutToOut;
            UnitsPerHour = result.UnitsPerHour;
            AutoOutRange = result.AutoOutRange;
        }
    }
}
