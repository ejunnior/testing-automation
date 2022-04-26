namespace Finance.Tests.Infrastructure.Api
{
    using System.Net.Http;
    using Microsoft.Data.SqlClient;
    using Xunit;

    [Collection(FixtureBaseCollection.Name)]
    public class ControllerBaseTest<TFixture>
        where TFixture : FixtureBase
    {
        private readonly TFixture _fixture;

        public ControllerBaseTest(TFixture fixture)
        {
            _fixture = fixture;

            HttpClient = _fixture
                .CreateClient();
        }

        protected SqlConnection Connection => _fixture.Connection;

        protected HttpClient HttpClient { get; }
    }
}