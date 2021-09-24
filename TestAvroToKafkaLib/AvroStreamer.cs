namespace TestAvroToKafkaLib
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Net;
    using System.Threading.Tasks;
    using Confluent.Kafka;
    using Microsoft.Extensions.Options;
    using TestAvroToKafkaLib.Schema;

    public class AvroStreamer : IAvroStreamer
    {
        private readonly AvroStreamerOptions options;

        /// <summary>
        /// Initialises a new instance of the <see cref="AvroStreamer"/> class.
        /// </summary>
        /// <param name="options">Configuration options.</param>
        public AvroStreamer(IOptions<AvroStreamerOptions> options)
        {
            this.options = options.Value ?? throw new ArgumentNullException(nameof(options));
        }

        /// <inheritdoc/>
        public event EventHandler<StatusChangedEventArgs> ComparisonStatusChanged;

        /// <inheritdoc />
        public async Task GenerateAvroFromTableAsync(string tableName)
        {
            RaiseStatusChanged($"Generating AVRO from table {tableName}");

            using var connection = new SqlConnection(options.SourceConnectionString);
            using var command = new SqlCommand($"SELECT * FROM [{tableName}]", connection);
            await connection.OpenAsync();
            using var dr = await command.ExecuteReaderAsync(CommandBehavior.CloseConnection);
            while (await dr.ReadAsync())
            {
                var entity = new Entity();

                var i = 0;
                while (i < dr.FieldCount)
                {
                    switch (dr.GetName(i))
                    {
                        case "entity_id":
                            entity.entity_id = dr.GetString(i);
                            break;
                        case "entity_type":
                            entity.entity_type = dr.GetString(i);
                            break;
                        case "name":
                            entity.name = dr.GetString(i);
                            break;
                    }
                    i++;
                }

                await StreamAvroRecord(entity);
            }
        }

        private async Task StreamAvroRecord(Entity record)
        {
            RaiseStatusChanged($"Streaming entity {record.entity_id}");

            using var producer = new ProducerBuilder<Null, Entity>(GetProducerConfig()).Build();
            await producer.ProduceAsync("entity-avro3", new Message<Null, Entity> { Value = record });
        }

        private ProducerConfig GetProducerConfig() =>
            new ProducerConfig
            {
                BootstrapServers = options.BootstrapServers,
                ClientId = Dns.GetHostName(),
            };

        protected virtual void RaiseStatusChanged(string message) =>
            this.ComparisonStatusChanged?.Invoke(this, new StatusChangedEventArgs(message));

        //private CachedSchemaRegistryClient GetRegistryClient() =>
        //    new CachedSchemaRegistryClient(new SchemaRegistryConfig
        //    {
        //        Url = options.SchemaRegistryUrl,
        //    });
    }
}
