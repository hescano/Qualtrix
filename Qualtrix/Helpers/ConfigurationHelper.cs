using System.Configuration;

namespace Qualtrix.Helpers
{
    /// <summary>
    /// Obtains settings from an application configuration file.
    /// </summary>
    public class ConfigurationHelper
    {
        public static string BaseQualtricsApiUri => ConfigurationManager.AppSettings["BaseQualtricsApiUri"];
        public static string XApiToken => ConfigurationManager.AppSettings["X-API-TOKEN"];
        public static string DataCenterId => ConfigurationManager.AppSettings["DataCenterId"];
    }
}
