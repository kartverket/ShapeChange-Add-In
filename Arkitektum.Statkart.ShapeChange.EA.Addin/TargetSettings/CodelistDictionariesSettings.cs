namespace Kartverket.ShapeChange.EA.Addin.TargetSettings
{
    public class CodelistDictionariesSettings
    {
        public string DirectoryName { get; }
        public bool IncludeEnumerations { get; }

        public CodelistDictionariesSettings(string directoryName, bool includeEnumerations)
        {
            DirectoryName = directoryName;
            IncludeEnumerations = includeEnumerations;
        }
    }
}
