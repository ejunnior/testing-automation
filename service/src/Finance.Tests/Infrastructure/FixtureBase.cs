namespace Finance.Tests.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using Api;
    using Finance.Api;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.TestHost;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public class FixtureBase
    {
        private readonly TestServer _apiServer;
        private readonly DatabaseFactory _databaseFactory = new DatabaseFactory();

        public FixtureBase()
        {
            _apiServer = CreateTestServer();
        }

        public HttpClient CreateClient()
        {
            var client = _apiServer
                .CreateClient();

            client.Timeout = TimeSpan
                .FromMinutes(5);

            return client;
        }

        private Dictionary<string, string> BuildInMemoryCollection()
        {
            return new Dictionary<string, string>
            {
                {"DatabaseConnectionString", _databaseFactory.GetConnection().ConnectionString}
            };
        }

        private TestServer CreateTestServer()
        {
            var builder = new WebHostBuilder()
                .UseConfiguration(new ConfigurationBuilder()
                    .AddInMemoryCollection(BuildInMemoryCollection())
                    .Build())
                .ConfigureAppConfiguration((context, config) =>
                {
                    context
                        .HostingEnvironment
                        .EnvironmentName = "Test";
                })
                .UseContentRoot(AppContext.BaseDirectory)
                .ConfigureTestServices(services =>
                {
                    //Configuracao de Mock Objects

                    services
                        .AddControllers()
                        .AddApplicationPart(typeof(Startup).Assembly);
                })
                .UseStartup(typeof(ApiTestStartup));

            return new TestServer(builder);
        }
    }
}