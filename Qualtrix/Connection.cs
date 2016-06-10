namespace Qualtrix
{
    /// <summary>
    /// Holds information about the connection, such as the DataCenterId, and the API token.
    /// </summary>
    public class Connection
    {
        //Properties
        public string DataCenterId { get; set; }
        public string ApiToken { get; set; }

        //Constructors
        public Connection(string dataCenterId, string apiToken)
        {
            DataCenterId = dataCenterId;
            ApiToken = apiToken;
        }
    }
}
