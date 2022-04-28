namespace Finance.Tests.Category
{
    using System.Collections.Specialized;
    using System.Net;
    using System.Threading.Tasks;
    using Fixtures;
    using FluentAssertions;
    using Infrastructure;
    using Infrastructure.Api;
    using Xunit;

    public class CategoryControllerTests
        : ControllerBaseTest<FixtureBase>
    {
        public CategoryControllerTests(FixtureBase fixture)
            : base(fixture)
        {
        }

        private string Path => "api/v1/category";

        [Fact]
        public async Task ShouldGetCategoryById()
        {
            // Arrange
            var category = new CategoryDtoFixture()
                .Build();

            await Connection
                .CreateCategoryAsync(category);

            var query = new NameValueCollection
            {
                {"id", "1"}
            };

            // Act
            var response = await HttpClient
                .GetAsync(GetUri(path: $"{Path}/1"));//, queryString: query));

            // Assert
            response
                .StatusCode
                .Should()
                .Be(HttpStatusCode.OK);
        }
    }
}