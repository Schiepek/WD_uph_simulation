using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPH_Simulation_ViewModel
{
    public class UnitVM : ViewModelBase
    {

        private int number;

        public int Number
        {
            get { return this.number; }
            set
            {
                if (this.number != value)
                {
                    this.number = value;
                    base.OnPropertyChanged("Number");
                }
            }
        }

        private bool hasComponent;

        public bool HasComponent
        {
            get { return this.hasComponent; }
            set
            {
                if (this.hasComponent != value)
                {
                    this.hasComponent = value;
                    base.OnPropertyChanged("HasComponent");
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
                    base.OnPropertyChanged("IsInAutostacker");
                }
            }
        }

        public UnitVM(int number, bool hasComponent, bool isInAutostacker)
        {
            this.number = number;
            this.hasComponent = hasComponent;
            this.isInAutostacker = isInAutostacker;
        }
    }
}
