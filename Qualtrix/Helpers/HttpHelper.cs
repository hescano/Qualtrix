using System;
using System.Net.Http;

namespace Qualtrix.Helpers
{
    /// <summary>
    /// Contains methods related to the HTTP protocol. Only GET, POST, DELETE, and PUT will be implemented
    /// as they are the only ones needed to implement the Qualtrics REST API.
    /// </summary>
    public class HttpHelper
    {
        /// <summary>
        /// Sends a HTTP GET request to the qualtrics server.
        /// </summary>
        /// <param name="subPath">The path of the URL that points to the resource.</param>
        /// <param name="connection">Connection object with the api token and datacenterid.</param>
        /// <returns>String with the contents returned from the HTTP GET method.</returns>
        public static string Get(string subPath, Connection connection)
        {
            string baseAddress = string.Format(ConfigurationHelper.BaseQualtricsApiUri, connection.DataCenterId);
            
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                client.DefaultRequestHeaders.Add("X-API-TOKEN", connection.ApiToken);

                var content = client.GetStringAsync(subPath);
                content.Wait();

                return content.Result;
            }
        }
    }
}
