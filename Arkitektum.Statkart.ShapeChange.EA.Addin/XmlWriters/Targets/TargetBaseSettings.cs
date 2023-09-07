namespace Kartverket.ShapeChange.EA.Addin
{
    internal abstract class TargetBaseSettings
    {
        public string OutputDirectory { get; }

        protected TargetBaseSettings(string outputDirectory)
        {
            OutputDirectory = outputDirectory;
        }
    }
}
