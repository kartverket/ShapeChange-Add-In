using System.IO;
using System.Xml;
using Kartverket.ShapeChange.EA.Addin.TargetSettings;

namespace Kartverket.ShapeChange.EA.Addin.Extensions
{
    public static class XmlSchemaWriter
    {
        public static void WriteXmlSchemaTarget(this XmlTextWriter writer, XmlSchemaSettings settings, string configDirectory)
        {
            writer.WriteStartElement("TargetXmlSchema");
            writer.WriteAttributeString("class", "de.interactive_instruments.ShapeChange.Target.XmlSchema.XmlSchema");
            writer.WriteAttributeString("mode", settings.Enabled ? "enabled" : "disabled");

            writer.WriteTargetParameterElement("outputDirectory", settings.DirectoryName);

            writer.WriteTargetParameterElement("defaultEncodingRule", settings.EncodingRule);

            writer.WriteIncludeElement(Path.Combine(configDirectory, "StandardRules.xml"));

            writer.WriteIncludeElement(Path.Combine(configDirectory, "StandardNamespaces.xml"));

            writer.WriteIncludeElement(Path.Combine(configDirectory, "StandardMapEntries.xml"));


            writer.WriteEndElement(); //close xsd
        }
    }
}
