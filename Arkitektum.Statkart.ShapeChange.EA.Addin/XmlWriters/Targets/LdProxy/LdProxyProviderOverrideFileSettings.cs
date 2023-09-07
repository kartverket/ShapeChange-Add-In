namespace Kartverket.ShapeChange.EA.Addin.LdProxy
{
    internal class LdProxyProviderOverrideFileSettings
    {
        public string Id { get; set; }
        public ConnectionInfo ConnectionInfo { get; set; }
    }

    internal class ConnectionInfo
    {
        public string ConnectorType { get; }
        public string Database { get; set; }
        public string Host { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Dialect { get; }
        public PathSyntax PathSyntax { get; set; }

        public ConnectionInfo()
        {
            ConnectorType = "SLICK";
            Dialect = "PGIS";
        }
    }

    internal class PathSyntax
    {
        public string DefaultPrimaryKey { get; }
        public string DefaultSortKey { get; }

        public PathSyntax(string primaryKey)
        {
            DefaultPrimaryKey = primaryKey;
            DefaultSortKey = primaryKey;
        }
    }
}
