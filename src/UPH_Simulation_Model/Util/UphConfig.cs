using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPH_Simulation_Model
{
    public static class UphConfig
    {
        public static int NumberOfRounds { get; set; }

        public static double StandardTransferTime { get; set; }

        public static int NumberOfDigits { get; set; }

        public static AutostackerMode AutostackerMode { get; set; }

        public static int MaxNumberOfZonesPerItem { get; private set; }

        public static int MaxNumberOfItems { get; private set; }

        public static int MinCapacityAutostacker { get; private set; }

        public static int MinDualZonesPerAutostacker { get; private set; }

        public static double TimeStep
        {
            get
            {
                switch (NumberOfDigits)
                {
                    case 1: return 0.1;
                    case 2: return 0.01;
                    default: return 0.01;
                }
            }
        }

        public static int OneSecondInSteps
        {
            get
            {
                switch (NumberOfDigits)
                {
                    case 1: return 10;
                    case 2: return 100;
                    default: return 10;
                }
            }
        }

        static UphConfig()
        {
            NumberOfRounds = 5;
            StandardTransferTime = 1.3;
            NumberOfDigits = 1;
            AutostackerMode = AutostackerMode.RoundRobin;
            MaxNumberOfZonesPerItem = 30;
            MaxNumberOfItems = 9999;
            MinCapacityAutostacker = 2;
            MinDualZonesPerAutostacker = 3;
        }

    }
}
