namespace Kartverket.ShapeChange.EA.Addin.CodeList
{
    internal class CodeListSettings : TargetBaseSettings
    {
        public bool GenerateEnums { get; }

        public CodeListSettings(string outputDirectory, bool generateEnums) : base(outputDirectory)
        {
            GenerateEnums = generateEnums;
        }
    }
}