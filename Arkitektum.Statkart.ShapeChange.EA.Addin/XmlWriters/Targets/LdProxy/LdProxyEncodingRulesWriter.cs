using System.Xml;

namespace Kartverket.ShapeChange.EA.Addin.LdProxy
{
    internal static class LdProxyEncodingRulesWriter
    {
        public static void WriteLdproxyEncodingRules(this XmlWriter writer)
        {
            writer.WriteStartElement("rules");

            writer.WriteStartElement("EncodingRule");
            writer.WriteAttributeString("name", "ldp_standard");

            writer.WriteRuleElement("rule-ldp2-all-documentation");
            writer.WriteRuleElement("rule-ldp2-cls-identifierStereotype");
            writer.WriteRuleElement("rule-ldp2-cls-codelist-direct");

            writer.WriteEndElement();

            writer.WriteEndElement();
        }

        private static void WriteRuleElement(this XmlWriter writer, string ruleName)
        {
            writer.WriteStartElement("rule");
            writer.WriteAttributeString("name", ruleName);
            writer.WriteEndElement();
        }
    }
}
