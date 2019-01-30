using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;

namespace UPH_Simulation_Model
{
    public class UphXmlSchemaValidator
    {
        private readonly string schemaResource = "UPH_Simulation_Model.Properties.Resources";

        private readonly string schemaName = "uphschema";

        public void Execute(string filepath)
        {
            XmlReaderSettings uphSimulationSettings = new XmlReaderSettings();
            XmlSchema xmlSchema = ResolveSchemaOutOfResources();

            uphSimulationSettings.Schemas.Add(xmlSchema);
            uphSimulationSettings.ValidationType = ValidationType.Schema;
            uphSimulationSettings.ValidationEventHandler += new ValidationEventHandler(UphXmlSettingsValidationHandler);

            XmlReader xmlReader = XmlReader.Create(filepath , uphSimulationSettings);

            while (xmlReader.Read()) { }
        }
        private XmlSchema ResolveSchemaOutOfResources()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            ResourceManager resourceManager = new ResourceManager(schemaResource, Assembly.GetExecutingAssembly());
            string schemaString = resourceManager.GetString(schemaName);
            Stream schemaStream = new MemoryStream(Encoding.UTF8.GetBytes(schemaString));
            return XmlSchema.Read(schemaStream, UphXmlSettingsValidationHandler);
        }

        private void UphXmlSettingsValidationHandler(object sender, ValidationEventArgs e)
        {
            if (e.Severity == XmlSeverityType.Warning)
            {
                throw new UphXmlException("Validation warning: " + e.Message);
            }
            else if (e.Severity == XmlSeverityType.Error)
            {
                throw new UphXmlException("Validation error: " + e.Message);
            }
        }


    }
}
