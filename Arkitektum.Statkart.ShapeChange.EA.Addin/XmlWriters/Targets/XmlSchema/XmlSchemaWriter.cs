using System.IO;
using System.Xml;
using Kartverket.ShapeChange.EA.Addin.Util;

namespace Kartverket.ShapeChange.EA.Addin.XmlSchema
{
    internal static class XmlSchemaWriter
    {
        public static void WriteXmlSchemaTarget(this XmlWriter writer, XmlSchemaSettings settings)
        {
            writer.WriteStartElement("TargetXmlSchema");
            writer.WriteAttributeString("class", "de.interactive_instruments.ShapeChange.Target.XmlSchema.XmlSchema");
            writer.WriteAttributeString("mode", "enabled");

            writer.WriteTargetParameterElement("outputDirectory", settings.OutputDirectory);
            writer.WriteTargetParameterElement("defaultEncodingRule", settings.EncodingRule);

            writer.WriteIncludeElement(Path.Combine(settings.ConfigDirectory, "StandardRules.xml"));

            writer.WriteIncludeElement(Path.Combine(settings.ConfigDirectory, "StandardNamespaces.xml"));

            writer.WriteIncludeElement(Path.Combine(settings.ConfigDirectory, "StandardMapEntries.xml"));

            writer.WriteEndElement();
        }
    }
}
