using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UPH_Simulation_Model.Properties;

namespace UPH_Simulation_Model
{
    public class UphXmlParser
    {
        private readonly XNamespace nmspc = Resources.xmlNamespace;

        private readonly XDocument doc;

        private AssemblyLine assemblyLine;

        public UphXmlParser(XDocument doc)
        {
            this.doc = doc;
        }

        public AssemblyLine Parse()
        {
            XElement xRoot = doc.Root;
            string name = xRoot.Element(nmspc + "name").Value;
            int numberOfUnits = int.Parse(xRoot.Element(nmspc + "numberofunits").Value);
            assemblyLine = new AssemblyLine(name, numberOfUnits);
            LoopThroughAssemblyItems(xRoot);
            return assemblyLine;
        }

        private void LoopThroughAssemblyItems(XElement xRoot)
        {
            int assemblyItemCounter = 1;

            foreach (XElement xAssemblyItem in xRoot.Elements(nmspc + "assemblylineitem"))
            {
                AssemblyLineItem item;
                String name = xAssemblyItem.Element(nmspc + "name").Value;
                XElement capacityElement = xAssemblyItem.Element(nmspc + "capacity");
                if(capacityElement != null)
                {
                    int capacity = Convert.ToInt32(capacityElement.Value);
                    item = new Autostacker(assemblyItemCounter, name, capacity);
                } else
                {
                    item = new AssemblyLineItem(assemblyItemCounter, name);
                }                
                LoopThroughPositions(xAssemblyItem, item);
                assemblyLine.Add(item);
                assemblyItemCounter++;
            }
        }

        private void LoopThroughPositions(XElement xAssemblyLineItem, AssemblyLineItem item)
        {
            int localNumber = 1;
            foreach (XElement xPosition in xAssemblyLineItem.Elements(nmspc + "position"))
            {
                Position position = new UphXmlPositionBuilder(xPosition).Build(localNumber, item.Number);
                item.Add(position);
                localNumber++;
            }
        }
    }

}
