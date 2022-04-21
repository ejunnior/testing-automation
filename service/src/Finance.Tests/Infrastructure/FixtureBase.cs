namespace Finance.Tests.Infrastructure
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.TestHost;

    public class FixtureBase
    {
        private readonly DatabaseFactory _databaseFactory = new DatabaseFactory();

        private Dictionary<string, string> BuildInMemoryCollection()
        {
            return new Dictionary<string, string>
            {
                {"DatabaseConnectionString", _databaseFactory.GetConnection().ConnectionString}
            };
        }

        private TestServer CreateTestServer()
        {
        }
    }
}