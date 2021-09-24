namespace TestAvroToKafkaLib
{
    using System;
    using System.Threading.Tasks;

    public interface IAvroStreamer
    {
        /// <summary>
        /// Generate the AVRO data based on the specified source SQL Server table.
        /// </summary>
        /// <param name="tableName">Name of source SQL Server table.</param>
        Task GenerateAvroFromTableAsync(string tableName);

        /// <summary> Handler for when the status message changes. </summary>
        event EventHandler<StatusChangedEventArgs> ComparisonStatusChanged;
    }
}