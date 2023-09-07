using System.Xml;
using Kartverket.ShapeChange.EA.Addin.Util;

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
    }
}
