namespace TestAvroToKafkaConsoleApp
{
    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Microsoft.Extensions.DependencyInjection;
    using TestAvroToKafkaLib;

    class Program
    {
        static async Task Main(string[] args)
        {
            // Get AvroStreamer from container
            var streamer = GetServiceProvider()
                .GetService<IAvroStreamer>();

            // Attach an event handler for status changes
            streamer.ComparisonStatusChanged += OnComparisonStatusChanged;

            try
            {
                // Wait for class to do the work
                await streamer.GenerateAvroFromTableAsync("Entity");
            }
            catch (Exception ex)
            {
                // Display error details
                Console.Write(ex);
                Trace.Write(ex);
            }
            finally
            {
                // Wait for user input before closing
                Console.ReadKey();
            }
        }

        /// <summary> Gets the dependency injection container configured by <see cref="Startup"/>. </summary>
        /// <returns> An instance of <see cref="IServiceProvider"/>. </returns>
        private static IServiceProvider GetServiceProvider()
        {
            var services = new ServiceCollection();
            new Startup().ConfigureServices(services);
            return services.BuildServiceProvider();
        }

        /// <summary> Event handler for status changes. </summary>
        /// <param name="sender">Instance of the class emitting the event.</param>
        /// <param name="e">Instance of <see cref="StatusChangedEventArgs"/>.</param>
        private static void OnComparisonStatusChanged(object sender, StatusChangedEventArgs e)
        {
            // Show status on-screen
            Console.Write($"\r{e.StatusMessage,-80}");

            // Write status (with time) to debug output
            Trace.WriteLine($"[{DateTime.UtcNow:HH:mm:ss.ff}] {e.StatusMessage}");
        }
    }
}
