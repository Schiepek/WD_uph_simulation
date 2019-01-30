using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPH_Simulation_Model
{
    public class Autostacker : AssemblyLineItem
    {

        private readonly int standartCapacity = 3;

        private int capacity;

        public int Capacity
        {
            get { return this.capacity; }
            set
            {
                if (this.capacity != value)
                {
                    this.capacity = value;
                    this.NotifyPropertyChanged("Capacity");
                }
            }
        }

        public int RoundRobinCapacity { get; set; }

        private bool roundRobinState;

        public bool CapacityReached
        {
            get
            {
                return ActiveZoneCount >= Capacity;
            }
        }

        public int ActiveZoneCount
        {
            get
            {
                int count = 0;
                foreach (Position position in Positions)
                {
                    if (position.IsActive())
                    {
                        count++;
                    }
                }
                return count;
            }
        }

        public bool IsLastAutoStackerDualZone(DualZone dualZone)
        {
            List<Position> dualZones = (from p in Positions
                                        where p is DualZone
                                        select p).ToList();

            if (dualZones.Any())
            {
                DualZone lastDualZone = (DualZone)dualZones.Last<Position>();
                return lastDualZone.Equals(dualZone);
            }
            return false;
        }

        public bool IsFirstAutoStackerZone(Position zone)
        {
            if (Positions.Any())
            {
                return Positions.First<Position>().Equals(zone);
            }
            return false;
        }

        public Autostacker(int number, string name) : base(number, name)
        {
            this.Capacity = standartCapacity;
        }

        public override void Reset()
        {
            RoundRobinCapacity = 0;
            roundRobinState = false;
            base.Reset();
        }

        public Autostacker(int number, string name, int capacity) : base(number, name)
        {
            this.Capacity = capacity;
        }

        public Autostacker GetNextAutostacker()
        {
            Position position = Positions.Last();

            while (true)
            {
                if (position.IsLastPosition)
                {
                    return null;
                }
                position = position.NextPosition;
                if (position.ParentItem is Autostacker)
                {
                    return (Autostacker)position.ParentItem;
                }
            }

        }

        public bool EvaluateRoundRobinState()
        {
            if (RoundRobinCapacity < Capacity)
            {
                RoundRobinCapacity++;
            }
            else
            {
                roundRobinState = roundRobinState ? false : true;
                RoundRobinCapacity = 1;
            }
            return roundRobinState;
        }

    }
}
