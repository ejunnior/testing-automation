namespace Finance.Tests.Fixtures
{
    using AutoFixture;

    public class CategoryDtoFixture
    {
        private readonly CategoryDto _dto;

        public CategoryDtoFixture()
        {
            var fixture = new Fixture();

            _dto = fixture
                .Create<CategoryDto>();
        }

        public CategoryDto Build()
        {
            return _dto;
        }

        public CategoryDtoFixture WithCategoryName(string categoryName)
        {
            _dto.Name = categoryName;
            return this;
        }
    }
}