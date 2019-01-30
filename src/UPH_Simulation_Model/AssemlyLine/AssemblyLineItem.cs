using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPH_Simulation_Model
{
    public class AssemblyLineItem : INotifyPropertyChanged
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
                    this.NotifyPropertyChanged("Number");
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
                    this.NotifyPropertyChanged("Name");
                }
            }
        }

        public TrulyObservableCollection<Position> Positions { get; set; }

        public List<double> OutToOuts = new List<double>();

        private double outToOut;

        public double OutToOut
        {
            get { return this.outToOut; }
            set
            {
                if (this.outToOut != value)
                {
                    this.outToOut = value;
                    this.NotifyPropertyChanged("OutToOut");
                }
            }
        }

        public AssemblyLineItem()
        {
            this.Name = "item";
            this.Positions = new TrulyObservableCollection<Position>();
        }

        public AssemblyLineItem(int number, string name)
        {
            this.Number = number;
            this.Name = name;
            this.Positions = new TrulyObservableCollection<Position>();
        }
        public void Add()
        {
            if (Positions.Count < UphConfig.MaxNumberOfZonesPerItem)
            {
                Position position = new WorkZone();
                Position transfer = new TransferPosition();
                position.LocalNumber = Positions.Count + 1;
                Positions.Add(position);
                transfer.LocalNumber = Positions.Count + 1;
                Positions.Add(transfer);
            }
        }
        public void Add(Position position)
        {
            position.LocalNumber = Positions.Count + 1;
            Positions.Add(position);
        }

        public void Delete(int localNumber)
        {
            Position position = Positions.Single(i => i.LocalNumber == localNumber);
            Positions.Remove(position);
            int index = position.LocalNumber - 1;
            for (int i = index; i < Positions.Count; i++)
            {
                Positions[i].LocalNumber = i + 1;
            }
        }

        public void Up(int localNumber)
        {
            Position position = Positions.Single(i => i.LocalNumber == localNumber);
            int newNumber = position.LocalNumber - 1;
            ExchangePositions(position, newNumber);
        }

        public void Down(int localNumber)
        {
            Position position = Positions.Single(i => i.LocalNumber == localNumber);
            int newNumber = position.LocalNumber + 1;
            ExchangePositions(position, newNumber);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        public virtual void Reset()
        {
            OutToOuts.Clear();
            OutToOut = 0.0;
            NotifyPropertyChanged("OutToOut");
        }

        public void CalculateOutToOut()
        {
            if (OutToOuts.Any())
            {
                OutToOut = OutToOuts.Average<double>(d => d);
            }
        }

        private bool NewLocalNumberIsInRange(int newLocalNumber)
        {
            return newLocalNumber > 0 && newLocalNumber <= Positions.Count;
        }

        private void ExchangePositions(Position position, int newNumber)
        {
            int oldNumber = position.LocalNumber;

            if (NewLocalNumberIsInRange(newNumber))
            {
                Positions.Move(oldNumber - 1, newNumber - 1);
                position.LocalNumber = newNumber;
                Positions[oldNumber - 1].LocalNumber = oldNumber;
            }
        }
    }
}
