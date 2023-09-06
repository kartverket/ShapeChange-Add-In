namespace Kartverket.ShapeChange.EA.Addin.TargetSettings
{
    public class FeatureCatalogueSettings
    {
        public string Directory { get; }
        public string Format { get; }
        public string Description { get; }
        public string Version { get; }
        public string VersionDate { get; }
        public string Producer { get; }
        public string DocxTemplateFullFilename { get; }
        public string FeatureTerm { get; }
        public bool IncludeDiagrams { get; }
        public bool IncludeTitle { get; }
        public bool IncludeVoidable { get; }
        

        public FeatureCatalogueSettings(
            string directory,
            string format,
            string description,
            string version,
            string versionDate,
            string producer,
            string docxTemplateFullFilename,
            string featureTerm,
            bool includeDiagrams,
            bool includeTitle,
            bool includeVoidable)
        {
            Directory = directory;
            Format = format;
            Description = description;
            Version = version;
            VersionDate = versionDate;
            Producer = producer;
            DocxTemplateFullFilename = docxTemplateFullFilename;
            FeatureTerm = featureTerm;
            IncludeDiagrams = includeDiagrams;
            IncludeTitle = includeTitle;
            IncludeVoidable = includeVoidable;
        }
    }
}
