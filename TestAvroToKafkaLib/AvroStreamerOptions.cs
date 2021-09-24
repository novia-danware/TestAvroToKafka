namespace TestAvroToKafkaLib
{
    /// <summary>
    /// Class to represent configuration options for the application.
    /// </summary>
    public class AvroStreamerOptions
    {
        /// <summary> Gets or sets the source connection string. </summary>
        public string SourceConnectionString { get; set; }

        /// <summary> Gets or sets the bootstrap server/port combinations. </summary>
        public string BootstrapServers { get; set; }

        /// <summary> Gets or sets the schema registry URL. </summary>
        public string SchemaRegistryUrl { get; set; }
    }
}
