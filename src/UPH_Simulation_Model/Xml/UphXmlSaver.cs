using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Schema;
using UPH_Simulation_Model.Properties;

namespace UPH_Simulation_Model
{
    public class UphXmlSaver
    {
        private readonly XNamespace nmspc = Resources.xmlNamespace;

        private readonly AssemblyLine assemblyLine;

        public UphXmlSaver(AssemblyLine assemblyLine)
        {
            this.assemblyLine = assemblyLine;
        }

        public void Save(string filepath)
        {
            UphUtil.CheckIfDirectoryExists(filepath);

            XDocument doc = createDocument();

            doc.Save(filepath);
        }

        private XDocument createDocument()
        {
            XDocument doc = new XDocument();
            doc.Declaration = new XDeclaration("1.0", "utf8", null);
            XElement root = createRootElement();
            doc.Add(root);
            AddAssemblyLineItemsToRootElement(root);
            return doc;
        }

        private XElement createRootElement()
        {
            XElement root = new XElement(nmspc + "assemblyline");
            root.Add(new XElement(nmspc + "name", assemblyLine.Name));
            root.Add(new XElement(nmspc + "numberofunits", assemblyLine.NumberOfUnits));
            return root;
        }

        private void AddAssemblyLineItemsToRootElement(XElement root)
        {
            foreach (AssemblyLineItem item in assemblyLine.Items)
            {
                XElement itemElement = new XElement(nmspc + "assemblylineitem");
                itemElement.Add(new XElement(nmspc + "name", item.Name));
                if(item is Autostacker)
                {
                    Autostacker autostacker = (Autostacker)item;
                    itemElement.Add(new XElement(nmspc + "capacity", autostacker.Capacity));
                }
                root.Add(itemElement);
                AddPositionsToAssemblyLineItemElement(itemElement, item);
            }
        }

        private void AddPositionsToAssemblyLineItemElement(XElement itemElement, AssemblyLineItem item)
        {
            foreach(Position position in item.Positions)
            {
                XElement positionElement = new XElement(nmspc + "position");
                positionElement.Add(new XElement(nmspc + "name", position.Name));
                positionElement.Add(new XElement(nmspc + "type", determinePositionType(position)));
                positionElement.Add(new XElement(nmspc + "time", position.Time.TotalTime));

                if(position is DualZone)
                {
                    DualZone dualZone = (DualZone)position;
                    positionElement.Add(new XElement(nmspc + "lazytime", dualZone.LazyTime.TotalTime));
                    positionElement.Add(new XElement(nmspc + "operation", dualZone.Operation));
                }
                itemElement.Add(positionElement);
            }
        }

        private string determinePositionType(Position position)
        {
            if(position is WorkZone)
            {
                return "work";
            }
            if (position is BufferZone)
            {
                return "buffer";
            }
            if (position is DualZone)
            {
                return "dual";
            } else
            {
                return "transfer";
            }
        }
    }
}
