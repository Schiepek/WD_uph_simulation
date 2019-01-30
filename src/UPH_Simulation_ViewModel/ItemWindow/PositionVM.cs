using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPH_Simulation_Model;

namespace UPH_Simulation_ViewModel 
{
    public class PositionVM : ViewModelBase
    {
        public Position position;

        private AssemblyLineItem item;

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

        private string name;

        public string Name
        {
            get { return this.name; }
            set
            {
                if (this.name != value)
                {
                    this.name = value;
                    base.OnPropertyChanged("Name");
                }
            }
        }

        private PositionTypeVM type;

        public PositionTypeVM Type
        {
            get { return this.type; }
            set
            {
                if (this.type != value)
                {
                    this.type = value;
                    base.OnPropertyChanged("Type");
                }
            }
        }

        private double time;

        public double Time
        {
            get { return this.time; }
            set
            {
                if (this.time != value)
                {
                    this.time = value;
                    base.OnPropertyChanged("Time");
                }
            }
        }

        private double lazyTime;

        public double LazyTime {
            get { return this.lazyTime; }
            set
            {
                if (this.lazyTime != value)
                {
                    this.lazyTime = value;
                    base.OnPropertyChanged("LazyTime");
                }
            }
        }

        private string operation;

        public string Operation
        {
            get { return this.operation; }
            set
            {
                if (this.operation != value)
                {
                    this.operation = value;
                    base.OnPropertyChanged("Operation");
                }
            }
        }

        public bool IsWorkZone
        {
            get
            {
                return Type == PositionTypeVM.WORKZONE;
            }
        }

        public bool IsDualZone
        {
            get
            {
                return Type == PositionTypeVM.DUALZONE;
            }
        }

        public bool IsTransferZone
        {
            get
            {
                return Type == PositionTypeVM.TRANSFER;
            }
        }

        private bool isActive;

        public bool IsActive
        {
            get { return this.isActive; }
            set
            {
                if (this.isActive != value)
                {
                    this.isActive = value;
                    base.OnPropertyChanged("IsActive");
                }
            }
        }

        public bool IsCalculated
        {
            get
            {
                return !IsTransferZone && Rank != 0 && !UphMathUtil.Equals(WaitingTime,0.0);
            }
        }

        public UnitVM currentUnit;

        public UnitVM CurrentUnit
        {
            get { return this.currentUnit; }
            set
            {
                if (this.currentUnit != value)
                {
                    this.currentUnit = value;
                    base.OnPropertyChanged("CurrentUnit");
                }
            }
        }

        private PositionStateVM state;

        public PositionStateVM State
        {
            get { return this.state; }
            set
            {
                if (this.state != value)
                {
                    this.state = value;
                    base.OnPropertyChanged("State");
                }
            }
        }

        private double waitingTime;

        public double WaitingTime
        {
            get { return this.waitingTime; }
            set
            {
                if (this.waitingTime != value)
                {
                    this.waitingTime = value;
                    base.OnPropertyChanged("WaitingTime");
                }
            }
        }

        private int rank;

        public int Rank
        {
            get { return this.rank; }
            set
            {
                if (this.rank != value)
                {
                    this.rank = value;
                    base.OnPropertyChanged("Rank");
                }
            }
        }

        public string PositionInfo
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(Name);
                sb.AppendLine("Type: " + Type.ToString().ToLower());
                if(Type != PositionTypeVM.DUALZONE)
                {
                    if(Type == PositionTypeVM.TRANSFER)
                    {
                        sb.Append("Time: " + Math.Round(Time, 2));
                    }
                    else
                    {
                        sb.AppendLine("Time: " + Math.Round(Time, 2));
                    }
                } else
                {
                    sb.AppendLine("Time: " + Math.Round(Time, 2) + "/" + Math.Round(lazyTime, 2));
                    sb.AppendLine("Operation: " + Operation);
                }
                if(Type != PositionTypeVM.TRANSFER)
                {                    
                    if(UphMathUtil.Equals(WaitingTime, 0.0))
                    {
                        sb.Append("Waitingtime: " + Math.Round(WaitingTime, 2));
                    } else
                    {
                        sb.AppendLine("Waitingtime: " + Math.Round(WaitingTime, 2));
                        sb.Append("Waitingtime Rank: " + Rank);
                    }
                }
                return sb.ToString();
            }
        }

        public PositionVM(Position position, AssemblyLineItem item)
        {
            this.position = position;
            this.item = item;
            this.Name = position.Name;
            this.Number = position.LocalNumber;
            this.Time = position.Time.TotalTime;
            this.Type = getPositionType();
            this.State = PositionStateVM.FREE;
            if(position is DualZone)
            {
                DualZone dualZone = (DualZone)position;
                this.LazyTime = dualZone.LazyTime.TotalTime;
                this.Operation = dualZone.Operation;
            }
            this.PropertyChanged += handlePropertyChanged;
        }

        private PositionTypeVM getPositionType()
        {
            if(position is WorkZone)
            {
                return PositionTypeVM.WORKZONE;
            }
            if(position is BufferZone)
            {
                return PositionTypeVM.BUFFERZONE;
            }
            if (position is DualZone)
            {
                return PositionTypeVM.DUALZONE;
            } else
            {
                return PositionTypeVM.TRANSFER;
            }
        }

        private void handlePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "Name":
                    position.Name = Name;
                    item.NotifyPropertyChanged("PositionProperty");
                    base.OnPropertyChanged("PositionInfo");
                    break;
                case "Time":
                    position.Time.TotalTime = Time;
                    item.NotifyPropertyChanged("PositionProperty");
                    base.OnPropertyChanged("PositionInfo");
                    break;
                case "Type":
                    changePositionType();
                    item.NotifyPropertyChanged("PositionProperty");
                    base.OnPropertyChanged("PositionInfo");
                    break;
                case "LazyTime":
                    DualZone dualZoneA = (DualZone)position;
                    dualZoneA.LazyTime.TotalTime = LazyTime;
                    item.NotifyPropertyChanged("PositionProperty");
                    base.OnPropertyChanged("PositionInfo");
                    break;
                case "Operation":
                    DualZone dualZoneB = (DualZone)position;
                    dualZoneB.Operation = Operation;
                    item.NotifyPropertyChanged("PositionProperty");
                    base.OnPropertyChanged("PositionInfo");
                    break;
                case "Rank":
                    base.OnPropertyChanged("IsCalculated");
                    base.OnPropertyChanged("PositionInfo");
                    break;
            }            
        }

        private void changePositionType()
        {
            switch (Type)
            {
                case PositionTypeVM.WORKZONE:
                    position = new WorkZone(Number, Name, Time);
                    break;
                case PositionTypeVM.BUFFERZONE:
                    position = new BufferZone(Number, Name, Time);
                    break;
                case PositionTypeVM.TRANSFER:
                    position = new TransferPosition(Number, Name, Time);
                    break;
                case PositionTypeVM.DUALZONE:
                    position = new DualZone(Number, Name, Time);
                    break;
            }
            item.Positions[Number - 1] = position;
        }
    }
}
