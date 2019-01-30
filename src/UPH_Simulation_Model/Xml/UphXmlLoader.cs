using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UPH_Simulation_Model
{
    public class UphXmlLoader
    {
        public AssemblyLine Load(string filepath)
        {
            UphUtil.CheckIfFileExists(filepath);
            new UphXmlSchemaValidator().Execute(filepath);
            XDocument doc = LoadXmlFile(filepath);
            return new UphXmlParser(doc).Parse();
        }
        
        private XDocument LoadXmlFile(string filepath)
        {
            try
            {
                return XDocument.Load(filepath);
            }
            catch (Exception e)
            {
                StringBuilder sb = new StringBuilder("Xml mistake in " + filepath + ": ");
                sb.AppendLine(e.Message);
                throw new UphXmlException(sb.ToString());
            }
        }
    }
}
