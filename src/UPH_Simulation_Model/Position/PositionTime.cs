using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPH_Simulation_Model
{
    public class PositionTime
    {
        public double TotalTime { get; set; }
        public double CurrentTime { get; private set; }

        public PositionTime(double totalTime)
        {
            this.TotalTime = totalTime;
        }

        public void IncreaseTime()
        {
            CurrentTime += UphConfig.TimeStep;
        }

        public void Reset()
        {
            CurrentTime = 0.0;
        }

        public bool TimeIsOver()
        {
            return UphMathUtil.IsGreaterThanOrEqualTo(CurrentTime, TotalTime);
        }

        public bool TimeExceeded()
        {
            return UphMathUtil.IsGreaterThan(CurrentTime, TotalTime);
        }

        public bool TimeIsRunning()
        {
            return UphMathUtil.IsBetweenOrEqualToRight(CurrentTime, 0.0, TotalTime);
        }

        public bool IsActive()
        {
            return !UphMathUtil.IsEqualTo(CurrentTime, 0.0);
        }
    }
}
