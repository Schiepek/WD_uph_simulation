using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPH_Simulation_ViewModel
{
    public enum PositionTypeVM
    {
        BUFFERZONE,
        DUALZONE,
        WORKZONE,
        TRANSFER
    }

    public static class PositionTypeExtensions
    {
        public static string ToString(this PositionTypeVM type)
        {
            switch (type)
            {
                case PositionTypeVM.BUFFERZONE:
                    return "Bufferzone";
                case PositionTypeVM.DUALZONE:
                    return "Dualzone";
                case PositionTypeVM.WORKZONE:
                    return "Workzone";
                case PositionTypeVM.TRANSFER:
                    return "Transfer";
            }
            return null;
        }
    }


}
