using System.Xml;

namespace Kartverket.ShapeChange.EA.Addin.Extensions
{
    public static class XmlTextWriterExtensions
    {
        public static void WriteIncludeElement(this XmlTextWriter writer, string href)
        {
            writer.WriteStartElement("include", "http://www.w3.org/2001/XInclude");
            writer.WriteAttributeString("href", href);
            writer.WriteEndElement();
        }

        public static void WriteParameterElement(this XmlTextWriter writer, string name, string value)
        {
            writer.WriteStartElement("parameter");
            writer.WriteAttributeString("name", name);
            writer.WriteAttributeString("value", value);
            writer.WriteEndElement();
        }

        public static void WriteTargetParameterElement(this XmlTextWriter writer, string name, string value)
        {
            writer.WriteStartElement("targetParameter");
            writer.WriteAttributeString("name", name);
            writer.WriteAttributeString("value", value);
            writer.WriteEndElement();
        }
    }
}
