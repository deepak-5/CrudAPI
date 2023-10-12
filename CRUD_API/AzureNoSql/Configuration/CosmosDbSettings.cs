// AzureNoSql/Configuration/CosmosDbSettings.cs
namespace AzureNoSql.Configuration // or AzureNoSql.Settings, match your folder name
{
    /// <summary>
    /// Represents configuration settings for connecting to a Cosmos DB instance.
    /// </summary>
    public class CosmosDbSettings
    {
        /// <summary>
        /// Gets or sets the connection string for Cosmos DB.
        /// </summary>
        public string CosmosConnectionString { get; set; }

        /// <summary>
        /// Gets or sets the name of the Cosmos DB database.
        /// </summary>
        public string DatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the name of the Cosmos DB container.
        /// </summary>
        public string ContainerName { get; set; }
    }
}
