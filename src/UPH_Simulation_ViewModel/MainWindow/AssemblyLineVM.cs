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
    public class AssemblyLineVM : ViewModelBase
    {
        private readonly string windowTitleFirstPart = "WD Uph Simulation - ";

        private UphSimulation uphSimulation;

        private AssemblyLine assemblyLine = new AssemblyLine();

        public ConfigVM ConfigVM { get; private set; }

        public AssemblyLine AssemblyLine
        {
            get { return this.assemblyLine; }
            set
            {
                if (this.assemblyLine != value)
                {
                    this.assemblyLine = value;
                    base.OnPropertyChanged("AssemblyLine");
                }
            }
        }

        public CommandMap Commands { get; set; }

        private string windowTitle;

        public string WindowTitle
        {
            get { return this.windowTitle; }
            set
            {
                if (this.windowTitle != value)
                {
                    this.windowTitle = value;
                    base.OnPropertyChanged("WindowTitle");
                }
            }
        }

        public string Filepath { get; set; }

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

        private int numberOfUnits;

        public int NumberOfUnits
        {
            get { return this.numberOfUnits; }
            set
            {
                if (this.numberOfUnits != value)
                {
                    this.numberOfUnits = value;
                    base.OnPropertyChanged("NumberOfUnits");
                }
            }
        }

        private double transferTime;

        public double TransferTime
        {
            get { return this.transferTime; }
            set
            {
                if (this.transferTime != value)
                {
                    this.transferTime = value;
                    base.OnPropertyChanged("TransferTime");
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

        private double round;

        public double Round
        {
            get { return this.round; }
            set
            {
                if (this.round != value)
                {
                    this.round = value;
                    base.OnPropertyChanged("Round");
                }
            }
        }

        public AssemblyLineItemVM Last
        {
            get
            {
                return ItemVMs.Last<AssemblyLineItemVM>();
            }
        }

        private AssemblyLineItemVM row;

        public AssemblyLineItemVM Row
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

        public ResultVM ResultVM { get; set; }

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

        private ObservableCollection<AssemblyLineItemVM> itemVMs;

        public ObservableCollection<AssemblyLineItemVM> ItemVMs
        {
            get { return itemVMs; }
            set
            {
                if (itemVMs != value)
                {
                    itemVMs = value;
                    base.OnPropertyChanged("ItemVMs");
                }
            }
        }

        public double MinWaitingTime
        {
            get
            {
                return assemblyLine.MinWaitingTime();
            }
        }

        public double MaxWaitingTime
        {
            get
            {
                return assemblyLine.MaxWaitingTime();
            }
        }

        public String WaitingTimeInfo
        {
            get
            {
                return new RankListString(GetPositions()).Create(ResultVM.Result);
            }
        }

        public AssemblyLineVM()
        {
            this.windowTitle = windowTitleFirstPart + assemblyLine.Name;
            this.Name = assemblyLine.Name;
            this.ResultVM = new ResultVM(ItemVMs);
            this.ConfigVM = new ConfigVM();
            this.NumberOfUnits = assemblyLine.NumberOfUnits;
            this.TransferTime = UphConfig.StandardTransferTime;
            this.uphSimulation = new UphSimulation(assemblyLine);
            PropertyChanged += HandlePropertyChanged;
            InitiateViewModelCollection();
            InitiateCommands();
        }

        public ObservableCollection<PositionVM> GetPositions()
        {
            ObservableCollection<PositionVM> positionVMs = new ObservableCollection<PositionVM>();
            foreach (AssemblyLineItemVM itemVM in ItemVMs)
            {
                foreach (PositionVM positionVM in itemVM.PositionVMs)
                {
                    positionVMs.Add(positionVM);
                }
            }
            return positionVMs;
        }

        private void InitiateViewModelCollection()
        {
            TrulyObservableCollection<AssemblyLineItem> source = assemblyLine.Items;
            Action<AssemblyLineItem, string> viewModelConverter = ConvertToViewModel;
            ItemVMs = new ObservableViewModelCollection<AssemblyLineItemVM, AssemblyLineItem>(source, CreateViewModel, viewModelConverter);
            ItemVMs.CollectionChanged += HandleItemsCollectionChanged;
            ResultVM.PropertyChanged += HandleResultChanged;
            uphSimulation.Algorithm.PropertyChanged += HandleAlgorithmChanged;
        }

        private void InitiateCommands()
        {
            this.Commands = new CommandMap();
            Commands.AddCommand("Up", param => assemblyLine.Up(Row.Number));
            Commands.AddCommand("Down", param => assemblyLine.Down(Row.Number));
            Commands.AddCommand("Add", param => assemblyLine.Add());
            Commands.AddCommand("Delete", param => assemblyLine.Delete(Row.Number));
            Commands.AddCommand("SetTransferTime", param => assemblyLine.SetAllTransferTimes(TransferTime));
            Commands.AddCommand("New", delegate(object param) {  AssemblyLine = new AssemblyLine(); Filepath = null; });
            Commands.AddCommand("Load", param => AssemblyLine = new UphXmlLoader().Load((string)param));
            Commands.AddCommand("Save", param => new UphXmlSaver(AssemblyLine).Save(Filepath), (param) => Filepath != null);
            Commands.AddCommand("SaveAs", param => new UphXmlSaver(AssemblyLine).Save((string)param));
            Commands.AddCommand("Calculate", param => uphSimulation.CalculateResult());
            Commands.AddCommand("ProceedOneTimeStep", param => uphSimulation.ProceedOneTimeStep());
            Commands.AddCommand("ProceedOneSecond", param => uphSimulation.ProceedOneSecond());
            Commands.AddCommand("ProceedOneRound", param => uphSimulation.ProceedOneRound());
            Commands.AddCommand("Reset", param => uphSimulation.Reset());
            Commands.AddCommand("SelectItem", param => uphSimulation.Reset());
        }

        private void InitiateViewTitle()
        {
            WindowTitle = windowTitleFirstPart + assemblyLine.Name;
        }

        private void HandleItemsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            uphSimulation.Reset();
        }

        private AssemblyLineItemVM CreateViewModel(AssemblyLineItem item)
        {
            AssemblyLineItemVM itemVM = new AssemblyLineItemVM(item);
            itemVM.PropertyChanged += HandleItemChanged;
            return itemVM;
        }

        private void ConvertToViewModel(AssemblyLineItem item, string propertyName)
        {
            if (item.Number <= ItemVMs.Count)
            {
                AssemblyLineItemVM itemVM = ItemVMs[item.Number - 1];
                switch (propertyName)
                {
                    case "Number":
                        itemVM.Number = item.Number;
                        uphSimulation.Reset();
                        break;
                    case "Capacity":
                        Autostacker autostacker = (Autostacker)item;
                        itemVM.Capacity = autostacker.Capacity;
                        uphSimulation.Reset();
                        break;
                    case "PositionProperty":
                        uphSimulation.Reset();
                        break;
                    case "PositionCollection":
                        uphSimulation.Reset();
                        break;
                    case "OutToOut":
                        itemVM.OutToOut = Math.Round(item.OutToOut, 2);
                        break;
                }
            }

        }

        private void HandlePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "Row":
                    RowIsSelected = Row != null;
                    foreach (AssemblyLineItemVM itemVM in ItemVMs)
                    {
                        itemVM.IsSelected = false;
                    }
                    if (Row != null)
                    {
                        Row.IsSelected = true;
                    }
                    break;
                case "AssemblyLine":
                    InitiateViewTitle();
                    Name = assemblyLine.Name;
                    NumberOfUnits = assemblyLine.NumberOfUnits;
                    TransferTime = assemblyLine.GetGeneralTransferTime();
                    uphSimulation = new UphSimulation(AssemblyLine);
                    Time = uphSimulation.Algorithm.Time;
                    Round = uphSimulation.Algorithm.Round;
                    InitiateViewModelCollection();
                    break;
                case "Name":
                    assemblyLine.Name = Name;
                    InitiateViewTitle();
                    break;
                case "NumberOfUnits":
                    assemblyLine.NumberOfUnits = NumberOfUnits;
                    uphSimulation.Reset();
                    break;
            }
        }

        private void HandleResultChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "Result":
                    Time = Math.Round(uphSimulation.Algorithm.Time, 2);
                    base.OnPropertyChanged("WaitingTimeInfo");
                    break;
            }
        }

        private void HandleItemChanged(object sender, PropertyChangedEventArgs e)
        {
            AssemblyLineItemVM itemVM = (AssemblyLineItemVM)sender;
            switch (e.PropertyName)
            {
                case "Item":
                    assemblyLine.Items[itemVM.Number - 1] = itemVM.Item;
                    break;
            }
        }

        private void HandleAlgorithmChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "Time":
                    Time = Math.Round(uphSimulation.Algorithm.Time, 2);
                    base.OnPropertyChanged("Time");
                    break;
                case "Result":
                    ResultVM.Result = uphSimulation.Algorithm.Result;
                    break;
                case "Round":
                    Round = uphSimulation.Algorithm.Round;
                    break;
            }
        }
    }
}
