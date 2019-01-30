using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPH_Simulation_Model
{
    public class AssemblyLine
    {
        private readonly string noName = "unnamed_assembly_line";

        private readonly int initialNumberOfUnits = 20;

        public TrulyObservableCollection<AssemblyLineItem> Items { get; private set; }

        public string Name { get; set; }

        public int NumberOfUnits { get; set; }

        public Position FirstPosition
        {
            get
            {
                if (Items.Any())
                {
                    AssemblyLineItem firstItem = Items.First<AssemblyLineItem>();
                    if (firstItem.Positions.Any())
                    {
                        return firstItem.Positions.First<Position>();
                    }
                }
                return null;
            }
        }

        public Position LastPosition
        {
            get
            {
                List<Position> positions = GetPositions();
                if (positions.Any())
                {
                    return positions.Last<Position>();
                }
                return null;
            }
        }
        
        public AssemblyLine(string name, int numberOfUnits)
        {
            this.Name = name;
            this.NumberOfUnits = numberOfUnits;
            this.Items = new TrulyObservableCollection<AssemblyLineItem>();
        }

        public AssemblyLine()
        {
            this.Name = noName;
            this.NumberOfUnits = initialNumberOfUnits;
            Items = new TrulyObservableCollection<AssemblyLineItem>();
        }

        public void Add(AssemblyLineItem item)
        {
            item.Number = Items.Count + 1;
            Items.Add(item);
        }

        public void Add()
        {
            if(GetPositions().Count <= UphConfig.MaxNumberOfItems)
            {
                AssemblyLineItem item = new AssemblyLineItem();
                item.Number = Items.Count + 1;
                Items.Add(item);
            }
        }

        public void Delete(int number)
        {
            AssemblyLineItem item = Items.Single(i => i.Number == number);
            Items.Remove(item);
            int index = item.Number - 1;
            for (int i = index; i < Items.Count; i++)
            {
                Items[i].Number = i + 1;
            }
        }

        public void Up(int number)
        {
            AssemblyLineItem item = Items.Single(i => i.Number == number);
            int newNumber = item.Number - 1;
            ExchangePositions(item, newNumber);
        }

        public void Down(int number)
        {
            AssemblyLineItem item = Items.Single(i => i.Number == number);
            int newNumber = item.Number + 1;
            ExchangePositions(item, newNumber);
        }

        public List<Position> GetPositions()
        {
            List<Position> positions = new List<Position>();
            foreach (AssemblyLineItem item in Items)
            {
                foreach (Position position in item.Positions)
                {
                    positions.Add(position);
                }
            }
            return positions;
        }

        public AssemblyLineItem GetLastWorkingItem()
        {
            AssemblyLineItem lastItem = Items.Last<AssemblyLineItem>();
            if(lastItem.Positions.Count > 1)
            {
                return lastItem;
            } else if(lastItem.Positions.First<Position>() is TransferPosition)
            {
                int secondLastIndex = Items.Count-2;
                return Items[secondLastIndex];
            }
            return null;
        }

        public void Reset()
        {
            foreach(AssemblyLineItem item in Items)
            {
                item.Reset();
                foreach(Position position in item.Positions)
                {
                    position.Reset();
                }
            }
        }

        public double MinWaitingTime()
        {
            double min = double.MaxValue;
            foreach (Position position in GetPositions())
            {
                if (position.AverageWaitingTime != 0)
                {
                    if (position.AverageWaitingTime < min)
                    {
                        min = position.AverageWaitingTime;
                    }
                }
            }
            return min;
        }

        public double MaxWaitingTime()
        {
            return GetPositions().Max<Position>((p) => p.AverageWaitingTime);
        }

        public double GetGeneralTransferTime()
        {
            List<Position> transfers = GetTransferPositions();
            double transferTime = UphConfig.StandardTransferTime;
            if(transfers.Any())
            {
                transferTime = transfers.First<Position>().Time.TotalTime;
                Position nextPosition = null;
                for(int i =1; i<= transfers.Count; i++)
                {
                    if (i != transfers.Count)
                    {
                        nextPosition = transfers[i];
                    } else
                    {
                        nextPosition = transfers[0];
                    }
                    double nextTransferTime = nextPosition.Time.TotalTime;
                    if(!UphMathUtil.Equals(transferTime, nextTransferTime))
                    {
                        return transfers.First<Position>().Time.TotalTime;
                    }
                }
            }
            return transferTime;
        }

        public void SetAllTransferTimes(double transferTime)
        {
            foreach(Position position in GetTransferPositions())
            {
                position.Time.TotalTime = transferTime;
                position.NotifyPropertyChanged("Time");
            }
        }

        public int GetMaxPossibleUnitsInLine()
        {
            int zoneCounter = 0;
            foreach(AssemblyLineItem item in Items)
            {
                if(item is Autostacker)
                {
                    Autostacker autostacker = (Autostacker)item;
                    zoneCounter += autostacker.Capacity;
                }
                else
                {
                    foreach(Position position in item.Positions)
                    {
                        if(UphUtil.IsZone(position))
                        {
                            zoneCounter++;
                        }
                    }
                }
            }
            return zoneCounter-1;
        }

        private List<Position> GetTransferPositions()
        {
            List<Position> transfers = new List<Position>();
            foreach(Position position in GetPositions())
            {
                if(position is TransferPosition)
                {
                    transfers.Add(position);
                }
            }
            return transfers;
        }


        private bool NewLocalNumberIsInRange(int newNumber)
        {
            if (newNumber > 0 && newNumber <= Items.Count)
            {
                return true;
            }
            return false;
        }

        private void ExchangePositions(AssemblyLineItem item, int newNumber)
        {
            int oldNumber = item.Number;

            if (NewLocalNumberIsInRange(newNumber))
            {
                Items.Move(oldNumber - 1, newNumber - 1);
                item.Number = newNumber;
                Items[oldNumber - 1].Number = oldNumber;
            }
        }
    }
}
