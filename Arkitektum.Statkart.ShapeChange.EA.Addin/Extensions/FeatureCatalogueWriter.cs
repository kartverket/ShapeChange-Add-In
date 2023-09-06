using System.Xml;
using Kartverket.ShapeChange.EA.Addin.TargetSettings;

namespace Kartverket.ShapeChange.EA.Addin.Extensions
{
    public static class FeatureCatalogueWriter
    {
        public static void WriteFeatureCatalogueTarget(this XmlTextWriter writer, FeatureCatalogueSettings settings, string schemaName)
        {
            writer.WriteStartElement("Target");
            writer.WriteAttributeString("class", "de.interactive_instruments.ShapeChange.Target.FeatureCatalogue.FeatureCatalogue");
            writer.WriteAttributeString("mode", "enabled");

            writer.WriteTargetParameterElement("outputDirectory", settings.Directory);

            writer.WriteTargetParameterElement("outputFilename", "FeatureCatalogue");

            writer.WriteTargetParameterElement("inheritedProperties", "true");

            writer.WriteTargetParameterElement("outputFormat", settings.Format == "DOCX-COMPACT" ? "DOCX" : settings.Format);

            writer.WriteTargetParameterElement("name", schemaName);

            writer.WriteTargetParameterElement("scope", settings.Description);

            writer.WriteTargetParameterElement("versionNumber", settings.Version);

            writer.WriteTargetParameterElement("versionDate", settings.VersionDate);

            writer.WriteTargetParameterElement("producer", settings.Producer);

            writer.WriteTargetParameterElement("xsltPfad", settings.Directory);

            writer.WriteTargetParameterElement("xsltPath", settings.Directory);

            writer.WriteTargetParameterElement("xslhtmlFile", "html2.xsl");

            writer.WriteTargetParameterElement("xslframeHtmlFileName", "frameHtml.xsl");

            writer.WriteTargetParameterElement("xsldocxFile", settings.Format == "DOCX-COMPACT" ? "docx-compact.xsl" : "docx.xsl");

            writer.WriteTargetParameterElement("docxTemplateFilePath", settings.DocxTemplateFullFilename);

            writer.WriteTargetParameterElement("xslTransformerFactory", "net.sf.saxon.TransformerFactoryImpl");

            writer.WriteTargetParameterElement("featureTerm", settings.FeatureTerm);

            writer.WriteTargetParameterElement("includeDiagrams", settings.IncludeDiagrams ? "true" : "false");

            writer.WriteTargetParameterElement("includeTitle", settings.IncludeTitle ? "true" : "false");

            writer.WriteTargetParameterElement("includeVoidable", settings.IncludeVoidable ? "true" : "false");

            writer.WriteEndElement();
        }
    }
}
