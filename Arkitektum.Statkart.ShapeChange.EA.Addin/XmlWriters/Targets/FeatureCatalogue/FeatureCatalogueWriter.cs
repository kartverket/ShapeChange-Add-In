using System.IO;
using System.Xml;
using Kartverket.ShapeChange.EA.Addin.Util;

namespace Kartverket.ShapeChange.EA.Addin.FeatureCatalogue
{
    internal static class FeatureCatalogueWriter
    {
        public static void WriteFeatureCatalogueTarget(this XmlWriter writer, FeatureCatalogueSettings settings)
        {
            writer.WriteTargetStartElement("de.interactive_instruments.ShapeChange.Target.FeatureCatalogue.FeatureCatalogue");

            writer.WriteTargetParameterElement("outputDirectory", settings.OutputDirectory);

            writer.WriteTargetParameterElement("outputFilename", "FeatureCatalogue");

            writer.WriteTargetParameterElement("inheritedProperties", "true");

            writer.WriteTargetParameterElement("outputFormat",
                settings.OutputFormat == "DOCX-COMPACT" ? "DOCX" : settings.OutputFormat);

            writer.WriteTargetParameterElement("name", settings.SchemaName);

            writer.WriteTargetParameterElement("scope", settings.Description);

            writer.WriteTargetParameterElement("versionNumber", settings.Version);

            writer.WriteTargetParameterElement("versionDate", settings.VersionDate);

            writer.WriteTargetParameterElement("producer", settings.Producer);

            writer.WriteTargetParameterElement("xsltPfad", settings.OutputDirectory);

            writer.WriteTargetParameterElement("xsltPath", settings.OutputDirectory);

            writer.WriteTargetParameterElement("xslhtmlFile", "html2.xsl");

            writer.WriteTargetParameterElement("xslframeHtmlFileName", "frameHtml.xsl");

            writer.WriteTargetParameterElement("xsldocxFile",
                settings.OutputFormat == "DOCX-COMPACT" ? "docx-compact.xsl" : "docx.xsl");

            writer.WriteTargetParameterElement("docxTemplateFilePath",
                Path.Combine(settings.TemplateDirectory, settings.TemplateFileName));

            writer.WriteTargetParameterElement("xslTransformerFactory", "net.sf.saxon.TransformerFactoryImpl");

            writer.WriteTargetParameterElement("featureTerm", settings.FeatureTerm);

            writer.WriteTargetParameterElement("includeDiagrams", settings.IncludeDiagrams.ToString().ToLower());

            writer.WriteTargetParameterElement("includeTitle", settings.IncludeTitle.ToString().ToLower());

            writer.WriteTargetParameterElement("includeVoidable", settings.IncludeVoidable.ToString().ToLower());

            writer.WriteEndElement(); //close FeatureCatalog target
        }
    }
}
