namespace Kartverket.ShapeChange.EA.Addin.FeatureCatalogue
{
    internal class FeatureCatalogueSettings : TargetBaseSettings
    {
        public string TemplateDirectory { get; }
        public string TemplateFileName { get; }
        public string OutputFormat { get; }
        public string SchemaName { get; }
        public string Description { get; }
        public string Version { get; }
        public string VersionDate { get; }
        public string Producer { get; }
        public string FeatureTerm { get; }
        public bool IncludeDiagrams { get; }
        public bool IncludeTitle { get; }
        public bool IncludeVoidable { get; }

        public FeatureCatalogueSettings(string outputDirectory, string templateDirectory, string templateFileName,
            string outputFormat, string schemaName, string description, string version, string versionDate,
            string producer, string featureTerm, bool includeDiagrams, bool includeTitle, bool includeVoidable) 
            : base(outputDirectory)
        {
            TemplateDirectory = templateDirectory;
            TemplateFileName = templateFileName;
            OutputFormat = outputFormat;
            SchemaName = schemaName;
            Description = description;
            Version = version;
            VersionDate = versionDate;
            Producer = producer;
            FeatureTerm = featureTerm;
            IncludeDiagrams = includeDiagrams;
            IncludeTitle = includeTitle;
            IncludeVoidable = includeVoidable;
        }
    }
}