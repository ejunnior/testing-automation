namespace Finance.Tests.Category
{
    using System.Threading.Tasks;
    using Fixtures;
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

        [Fact]
        public async Task ShouldGetCategoryById()
        {
            // Arrange
            var category = new CategoryDtoFixture()
                .Build();

            await Connection
                .CreateCategoryAsync(category);

            // Act

            // Assert
        }
    }
}