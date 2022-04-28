namespace Finance.Tests.Infrastructure.Api
{
    using System;
    using System.Collections.Specialized;
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

        protected Uri GetUri(string path, NameValueCollection queryString = null)
        {
            var builder = new UriBuilder(FixtureBase.ApiHost)
            {
                Path = path
            };

            if (queryString != null)
            {
                builder.Query = queryString.ToQueryString();
            }

            return builder.Uri;
        }
    }
}