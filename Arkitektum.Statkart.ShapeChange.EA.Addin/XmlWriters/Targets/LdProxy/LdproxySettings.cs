namespace Kartverket.ShapeChange.EA.Addin.LdProxy
{
    internal class LdproxySettings : TargetBaseSettings
    {
        public string TemplatesDirectory { get; }
        public string Srid { get; }
        public string ServiceLabel { get; }
        public string ServiceDescription { get; }

        public LdproxySettings(string outputDirectory, string templatesDirectory, string srid, string serviceLabel,
            string serviceDescription) : base(outputDirectory)
        {
            TemplatesDirectory = templatesDirectory;
            Srid = srid;
            ServiceLabel = serviceLabel;
            ServiceDescription = serviceDescription;
        }
    }
}
