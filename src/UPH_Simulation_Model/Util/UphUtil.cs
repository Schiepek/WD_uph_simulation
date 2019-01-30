using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPH_Simulation_Model
{
    static class UphUtil
    {
        public static void CheckIfFileExists(string filepath)
        {
            if (!File.Exists(filepath))
            {
                string message = "file " + filepath + "does not exist";
                throw new UphXmlException(message);
            }
        }

        public static void CheckIfDirectoryExists(string filepath)
        {
            if (!Directory.Exists(Path.GetDirectoryName(filepath)))
            {
                string message = "directory for file " + filepath + "does not exist";
                throw new UphXmlException(message);
            }
        }

        public static bool RoundIsValid(int Round)
        {
            return Round > 0;
        }

        public static bool IsTransfer(Position position)
        {
            return position is TransferPosition;
        }

        public static bool IsZone(Position position)
        {
            return !IsTransfer(position);
        }
    }
}
