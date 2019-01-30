using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using UPH_Simulation_Model;

namespace UPH_Simulation_ViewModel
{
    public class AssemblyLineItemVM : ViewModelBase
    {
        private AssemblyLineItem item;

        public AssemblyLineItem Item
        {
            get { return this.item; }
            set
            {
                if (this.item != value)
                {
                    this.item = value;
                    base.OnPropertyChanged("Item");
                }
            }
        }

        private ObservableViewModelCollection<PositionVM, Position> positionVMs;

        public ObservableViewModelCollection<PositionVM, Position> PositionVMs
        {
            get
            {
                return positionVMs;
            }
            set
            {
                base.OnPropertyChanged("PositionVMs");
            }
        }

        public CommandMap Commands { get; set; }

        private int number;

        public int Number
        {
            get { return this.number; }
            set
            {
                if (this.number != value)
                {
                    this.number = item.Number;
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

        private int capacity;

        public int Capacity
        {
            get { return this.capacity; }
            set
            {
                if (this.capacity != value)
                {
                    this.capacity = value;
                    base.OnPropertyChanged("Capacity");
                }
            }
        }

        private double outToOut;

        public double OutToOut
        {
            get { return this.outToOut; }
            set
            {
                if (this.outToOut != value)
                {
                    this.outToOut = value;
                    base.OnPropertyChanged("OutToOut");
                }
            }
        }

        private bool isAutostacker;

        public bool IsAutostacker
        {
            get { return isAutostacker; }
            set
            {
                if (isAutostacker != value)
                {
                    isAutostacker = value;
                    base.OnPropertyChanged("IsAutostacker");
                }
            }
        }

        private PositionVM row;

        public PositionVM Row
        {
            get { return row; }
            set
            {
                if (row != value)
                {
                    row = value;
                    base.OnPropertyChanged("Row");
                }
            }
        }

        public bool rowIsSelected;

        public bool RowIsSelected
        {
            get { return rowIsSelected; }
            set
            {
                if (rowIsSelected != value)
                {
                    rowIsSelected = value;
                    base.OnPropertyChanged("RowIsSelected");
                }
            }
        }

        public bool isSelected;

        public bool IsSelected
        {
            get { return this.isSelected; }
            set
            {
                if (this.isSelected != value)
                {
                    this.isSelected = value;
                    base.OnPropertyChanged("IsSelected");
                }
            }
        }

        public AssemblyLineItemVM(AssemblyLineItem item)
        {
            this.item = item;
            this.Name = item.Name;
            this.Number = item.Number;
            if (item is Autostacker)
            {
                Autostacker autostacker = (Autostacker)item;
                this.IsAutostacker = true;
                this.Capacity = autostacker.Capacity;
            }
            this.PropertyChanged += HandlePropertyChanged;
            InitiateViewModelCollection(item);
            InitiateCommands();
        }

        private void InitiateViewModelCollection(AssemblyLineItem item)
        {
            TrulyObservableCollection<Position> source = item.Positions;
            Func<Position, PositionVM> viewModelCreator = model => new PositionVM(model, item);
            Action<Position, string> viewModelConverter = ConvertToViewModel;
            positionVMs = new ObservableViewModelCollection<PositionVM, Position>(source, viewModelCreator, viewModelConverter);
            positionVMs.CollectionChanged += HandlePositionsCollectionChanged;
        }

        private void InitiateCommands()
        {
            Commands = new CommandMap();
            Commands.AddCommand("Up", param => item.Up(Row.Number));
            Commands.AddCommand("Down", param => item.Down(Row.Number));
            Commands.AddCommand("Add", param => item.Add());
            Commands.AddCommand("Delete", param => item.Delete(Row.Number));
        }


        private void HandlePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "Name":
                    item.Name = Name;
                    break;
                case "IsAutostacker":
                    ChangeAutostackerState();
                    break;
                case "Capacity":
                    Autostacker autostacker = (Autostacker) item;
                    autostacker.Capacity = Capacity;
                    break;
                case "Row":
                    RowIsSelected = Row != null;
                    break;
            }
        }

        private void HandlePositionsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            item.NotifyPropertyChanged("PositionCollection");
        }

        private void ConvertToViewModel(Position position, string propertyName)
        {
            if (position.LocalNumber <= PositionVMs.Count)
            {
                PositionVM positionVM = PositionVMs[position.LocalNumber - 1];
                switch (propertyName)
                {
                    case "Number":
                        positionVM.Number = position.LocalNumber;
                        break;
                    case "Time":
                        positionVM.Time = position.Time.TotalTime;
                        break;
                    case "State":
                        ChangePositionState(position, positionVM);
                        break;
                    case "Rank":
                        positionVM.Rank = position.Rank;
                        break;
                    case "AverageWaitingTime":
                        positionVM.WaitingTime = position.AverageWaitingTime;
                        break;
                    case "PositionProperty":
                        base.OnPropertyChanged("PositionProperty");
                        break;
                    case "CurrentUnit":
                        Unit unit = position.CurrentUnit;
                        if (unit == null)
                        {
                            positionVM.IsActive = false;
                            positionVM.CurrentUnit = null;
                        }
                        else
                        {
                            positionVM.IsActive = true;
                            int number = unit.Number;
                            bool hasComponent = unit.HasComponent;
                            bool isInAutostacker = unit.IsInAutostacker;
                            UnitVM unitVM = new UnitVM(number, hasComponent, isInAutostacker);
                            positionVM.CurrentUnit = unitVM;
                        }
                        break;
                }
            }

        }

        private void ChangePositionState(Position position, PositionVM positionVM)
        {
            switch (position.State)
            {
                case PositionState.BUFFER:
                    positionVM.State = PositionStateVM.BUFFER;
                    break;
                case PositionState.WAIT:
                    positionVM.State = PositionStateVM.WAIT;
                    break;
                case PositionState.FREE:
                    positionVM.State = PositionStateVM.FREE;
                    break;
                case PositionState.WORK:
                    positionVM.State = PositionStateVM.WORK;
                    break;
                case PositionState.FINISHED:
                    positionVM.State = PositionStateVM.FINISHED;
                    break;
            }
        }

        private void ChangeAutostackerState()
        {
            if (IsAutostacker)
            {
                Autostacker autostacker = new Autostacker(Number, Name);
                autostacker.Positions = item.Positions;
                Item = autostacker;
            }
            else
            {
                AssemblyLineItem newItem = new AssemblyLineItem(Number, Name);
                newItem.Positions = item.Positions;
                Item = newItem;
            }
        }
    }
}
