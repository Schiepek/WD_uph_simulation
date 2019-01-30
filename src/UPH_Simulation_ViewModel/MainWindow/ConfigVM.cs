using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPH_Simulation_Model;

namespace UPH_Simulation_ViewModel
{
    public class ConfigVM : ViewModelBase
    {
        private int numberOfRounds;

        public int NumberOfRounds
        {
            get { return this.numberOfRounds; }
            set
            {
                if (this.numberOfRounds != value)
                {
                    this.numberOfRounds = value;
                    base.OnPropertyChanged("NumberOfRounds");
                }
            }
        }

        private double standardTransferTime;

        public double StandardTransferTime
        {
            get { return this.standardTransferTime; }
            set
            {
                if (this.standardTransferTime != value)
                {
                    this.standardTransferTime = value;
                    base.OnPropertyChanged("StandardTransferTime");
                }
            }
        }

        private int numberOfDitits;

        public int NumberOfDigits
        {
            get { return this.numberOfDitits; }
            set
            {
                if (this.numberOfDitits != value)
                {
                    this.numberOfDitits = value;
                    base.OnPropertyChanged("NumberOfDigits");
                }
            }
        }

        private AutostackerModeVM autostackerMode;

        public AutostackerModeVM AutostackerMode
        {
            get { return this.autostackerMode; }
            set
            {
                if (this.autostackerMode != value)
                {
                    this.autostackerMode = value;
                    base.OnPropertyChanged("AutostackerMode");
                }
            }
        }

        public ConfigVM()
        {
            this.NumberOfRounds = UphConfig.NumberOfRounds;
            this.StandardTransferTime = UphConfig.StandardTransferTime;
            this.NumberOfDigits = UphConfig.NumberOfDigits;
            this.AutostackerMode = GetAutostackerModeFromModel();
            this.PropertyChanged += HandlePropertyChanged;
        }


        private void HandlePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch(e.PropertyName)
            {
                case "NumberOfRounds":
                    UphConfig.NumberOfRounds = NumberOfRounds;
                    break;
                case "StandardTransferTime":
                    UphConfig.StandardTransferTime = StandardTransferTime;
                    break;
                case "NumberOfDigits":
                    UphConfig.NumberOfDigits = NumberOfDigits;
                    break;
                case "AutostackerMode":
                    UphConfig.AutostackerMode = GetAutostackerModeFromViewModel();
                    break;
            }
        }

        private AutostackerModeVM GetAutostackerModeFromModel()
        {
            switch (UphConfig.AutostackerMode)
            {
                case UPH_Simulation_Model.AutostackerMode.CheckCapacity:
                    return AutostackerModeVM.CheckCapacity;
                case UPH_Simulation_Model.AutostackerMode.RoundRobin:
                    return AutostackerModeVM.RoundRobin;
                default: return AutostackerModeVM.RoundRobin;
            }
        }

        private AutostackerMode GetAutostackerModeFromViewModel()
        {
            switch (AutostackerMode)
            {
                case AutostackerModeVM.CheckCapacity:
                    return UPH_Simulation_Model.AutostackerMode.CheckCapacity;
                case AutostackerModeVM.RoundRobin:
                    return UPH_Simulation_Model.AutostackerMode.RoundRobin;
                default: return UPH_Simulation_Model.AutostackerMode.RoundRobin;
            }
        }

    }
}
