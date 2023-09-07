using System.Xml;

namespace Kartverket.ShapeChange.EA.Addin.Util
{
    internal static class XmlWriterExtensions
    {
        public static void WriteParameterElement(this XmlWriter writer, string name, string value)
        {
            writer.WriteStartElement("parameter");
            writer.WriteAttributeString("name", name);
            writer.WriteAttributeString("value", value);
            writer.WriteEndElement();
        }

        public static void WriteTargetParameterElement(this XmlWriter writer, string name, string value)
        {
            writer.WriteStartElement("targetParameter");
            writer.WriteAttributeString("name", name);
            writer.WriteAttributeString("value", value);
            writer.WriteEndElement();
        }

        public static void WriteTransformerAttributes(this XmlWriter writer, string className, string input, string id)
        {
            writer.WriteAttributeString("class", className);
            writer.WriteAttributeString("input", input);
            writer.WriteAttributeString("id", id);
            writer.WriteAttributeString("mode", "enabled");
        }

        public static void WriteProcessParameterElement(this XmlWriter writer, string name, string value)
        {
            writer.WriteStartElement("ProcessParameter");
            writer.WriteAttributeString("name", name);
            writer.WriteAttributeString("value", value);
            writer.WriteEndElement();
        }

        public static void WriteTargetStartElement(this XmlWriter writer, string className, params string[] inputs)
        {
            writer.WriteStartElement("Target");
            writer.WriteAttributeString("class", className);
            writer.WriteAttributeString("mode", "enabled");
            if (inputs.Length > 0)
            {
                writer.WriteAttributeString("inputs", string.Join(",", inputs));
            }
        }

        public static void WriteIncludeElement(this XmlWriter writer, string hrefValue)
        {
            writer.WriteStartElement("include", "http://www.w3.org/2001/XInclude");
            writer.WriteAttributeString("href", hrefValue);
            writer.WriteEndElement();
        }

        public static void WriteRuleElement(this XmlWriter writer, string ruleName)
        {
            writer.WriteStartElement("rule");
            writer.WriteAttributeString("name", ruleName);
            writer.WriteEndElement();
        }
    }
}
