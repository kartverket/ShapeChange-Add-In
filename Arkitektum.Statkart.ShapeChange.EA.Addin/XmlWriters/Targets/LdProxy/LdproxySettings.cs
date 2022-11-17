namespace Kartverket.ShapeChange.EA.Addin.LdProxy
{
    internal class LdProxySettings : TargetBaseSettings
    {
        public string TemplatesDirectory { get; }
        public string Srid { get; }
        public string ServiceLabel { get; }
        public string ServiceDescription { get; }
        public string PrimaryKey { get; }

        public LdProxySettings(string outputDirectory, string templatesDirectory, string srid, string serviceLabel,
            string serviceDescription, string primaryKey) : base(outputDirectory)
        {
            TemplatesDirectory = templatesDirectory;
            Srid = srid;
            ServiceLabel = serviceLabel;
            ServiceDescription = serviceDescription;
            PrimaryKey = primaryKey;
        }
    }
}
