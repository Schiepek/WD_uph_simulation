using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPH_Simulation_Model
{
    public class Units
    {
        public List<Unit> units = new List<Unit>();

        public int LastUnitRound
        {
            get
            {
                if(units.Any())
                {
                    return units.Last<Unit>().Round;
                } else
                {
                    return 0;
                }
            }
        }

        public Units(int numberOfUnits)
        {
            InitiateUnits(numberOfUnits);
            InitiateNextPositions();
        }

        private void Add(Unit unit)
        {
            units.Add(unit);
        }

        public List<Unit> All()
        {
            return units;
        }

        public bool AllUnitsAreFinished(int numberOfRounds)
        {
            if (units.Any())
            {
                Unit unit = units.Last<Unit>();
                return unit.Round == numberOfRounds;
            }
            return false;
        }

        public bool AllUnitsAreInLine()
        {
            int unitInLineCounter = 0;
            if (units.Any())
            {
                foreach (Unit unit in units)
                {
                    if (unit.CurrentPosition != null)
                    {
                        unitInLineCounter++;
                    }
                }
            }
            return unitInLineCounter == units.Count;
        }

        private void InitiateUnits(int numberOfUnits)
        {
            for (int i = 1; i <= numberOfUnits; i++)
            {
                Unit unit = new Unit(i);
                Add(unit);
            }
        }

        private void InitiateNextPositions()
        {
            Unit oldUnit = null;
            foreach (Unit unit in units)
            {
                unit.NextUnit = oldUnit;
                oldUnit = unit;
            }
            units.First<Unit>().NextUnit = units.Last<Unit>();
        }
    }
}
