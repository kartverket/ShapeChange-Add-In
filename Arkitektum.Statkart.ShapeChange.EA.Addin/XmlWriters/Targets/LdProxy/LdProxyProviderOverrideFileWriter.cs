using System.IO;
using Microsoft.OpenApi.Writers;
using static Kartverket.ShapeChange.EA.Addin.Resources.LdProxy;

namespace Kartverket.ShapeChange.EA.Addin.LdProxy
{
    internal static class LdProxyProviderOverrideFileWriter
    {
        public static void WriteProviderOverrides(string resultDirectory, LdProxyProviderOverrideFileSettings settings)
        {
            var configurationFileDirectoryPath = Path.Combine(resultDirectory, InputId, "data", "store", "overrides", "providers");
            
            Directory.CreateDirectory(configurationFileDirectoryPath);

            var configurationFilePath = Path.Combine(configurationFileDirectoryPath, settings.Id);

            using (var writer = new StreamWriter(File.Create($"{configurationFilePath}.yml")))
            {
                var yamlWriter = new OpenApiYamlWriter(writer);

                yamlWriter.WriteStartObject();
                yamlWriter.WritePropertyName("id");
                yamlWriter.WriteValue(settings.Id);
                yamlWriter.WriteConnectionInfo(settings.ConnectionInfo);
                yamlWriter.WriteEndObject();
            }
        }

        private static void WriteConnectionInfo(this OpenApiWriterBase writer, ConnectionInfo connectionInfo)
        {
            writer.WritePropertyName("connectionInfo");
            writer.IncreaseIndentation();
            writer.WritePropertyName("connectorType");
            writer.WriteValue(connectionInfo.ConnectorType);
            writer.WritePropertyName("database");
            writer.WriteValue(connectionInfo.Database);
            writer.WritePropertyName("host");
            writer.WriteValue(connectionInfo.Host);
            writer.WritePropertyName("user");
            writer.WriteValue(connectionInfo.User);
            writer.WritePropertyName("password");
            writer.WriteValue(connectionInfo.Password);
            writer.WritePropertyName("dialect");
            writer.WriteValue(connectionInfo.Dialect);
            writer.WritePropertyName("computeNumberMatched");
            writer.WriteValue(true);
            writer.WritePropertyName("pathSyntax");
            writer.IncreaseIndentation();
            writer.WritePropertyName("defaultPrimaryKey");
            writer.WriteValue(connectionInfo.PathSyntax.DefaultPrimaryKey);
            writer.WritePropertyName("defaultSortKey");
            writer.WriteValue(connectionInfo.PathSyntax.DefaultSortKey);
        }
    }
}
