using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UPH_Simulation_Model.Properties;

namespace UPH_Simulation_Model
{
    public class UphXmlPositionBuilder
    {
        private readonly XNamespace nmspc = Resources.xmlNamespace;

        private readonly XElement xElement;
        public UphXmlPositionBuilder(XElement xElement)
        {
            this.xElement = xElement;
        }
        public Position Build(int number, int itemNumber)
        {
            string name = xElement.Element(nmspc + "name").Value;
            string type = xElement.Element(nmspc + "type").Value;
            double time = Convert.ToDouble(xElement.Element(nmspc + "time").Value);

            switch (type)
            {
                case "buffer": return new BufferZone(number, name, time);
                case "work": return new WorkZone(number, name, time);
                case "transfer": return new TransferPosition(number, name, time);
                case "dual": return CreateDualPosition(number, name, time);
                default: throw new UphXmlException("zone " + type + " does not exist");
            }
        }

        private Position CreateDualPosition(int number, string name, double time)
        {
            CheckDualPositionElements();
            double lazytime = Convert.ToDouble(xElement.Element(nmspc + "lazytime").Value); ;
            string operation = xElement.Element(nmspc + "operation").Value;
            return new DualZone(number, name, time, lazytime, operation);
        }

        private void CheckDualPositionElements()
        {
            string name = xElement.Element(nmspc + "name").Value;
            XElement xLazytime = xElement.Element(nmspc + "lazytime");
            XElement operation = xElement.Element(nmspc + "operation");
            if(xLazytime == null || operation == null)
            {
                String message = "Operation or lazytime of dualposition " + name + " not defined";
                throw new UphXmlException(message);
            }
        }


    }
}
