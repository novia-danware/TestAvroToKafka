namespace TestAvroToKafkaConsoleApp
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using TestAvroToKafkaLib;

    internal class Startup
    {
        private IConfigurationRoot Configuration { get; }

        public Startup() =>
            Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddUserSecrets<AvroStreamerOptions>()
                .Build();

        public void ConfigureServices(IServiceCollection services) =>
            services
                .AddSingleton(Configuration)
                .AddSingleton<IAvroStreamer, AvroStreamer>()
                .Configure<AvroStreamerOptions>(Configuration.GetSection(nameof(AvroStreamerOptions)));
    }
}
