using System.IO;
using System.Xml;
using Kartverket.ShapeChange.EA.Addin.Util;
using static Kartverket.ShapeChange.EA.Addin.Resources.LdProxy;

namespace Kartverket.ShapeChange.EA.Addin.LdProxy
{
    internal static class LdProxyWriter
    {
        public static void WriteLdProxyTarget(this XmlWriter writer, LdProxySettings settings)
        {
            writer.WriteTargetStartElement("de.interactive_instruments.ShapeChange.Target.Ldproxy2.Ldproxy2Target",
                InputId);

            writer.WriteTargetParameterElement("outputDirectory", settings.OutputDirectory);
            writer.WriteTargetParameterElement("sortedOutput", "true");
            writer.WriteTargetParameterElement("srid", settings.Srid);
            writer.WriteTargetParameterElement("forceAxisOrder", "LON_LAT");
            writer.WriteTargetParameterElement("cfgTemplatePath",
                Path.Combine(settings.TemplatesDirectory, "cfgTemplate.yml"));
            writer.WriteTargetParameterElement("serviceConfigTemplatePath",
                Path.Combine(settings.TemplatesDirectory, "serviceConfigTemplate.yml"));
            writer.WriteTargetParameterElement("defaultEncodingRule", "ldp_standard");
            writer.WriteTargetParameterElement("objectIdentifierName", settings.PrimaryKey);
            writer.WriteTargetParameterElement("serviceLabel", settings.ServiceLabel);
            writer.WriteTargetParameterElement("serviceDescription", settings.ServiceDescription);
            writer.WriteTargetParameterElement("dateFormat", "dd.MM.yyyy");
            writer.WriteTargetParameterElement("dateTimeFormat", "dd.MM.yyyy hh.mm.ss");
            writer.WriteTargetParameterElement("foreignKeyColumnSuffix", "_fk");

            writer.WriteLdproxyEncodingRules();

            writer.WriteIncludeElement("http://shapechange.net/resources/config/StandardRules.xml");
            writer.WriteIncludeElement("http://shapechange.net/resources/config/StandardMapEntries_Ldproxy2.xml");

            writer.WriteLdProxyMapEntries();

            writer.WriteEndElement();
        }
    }
}
