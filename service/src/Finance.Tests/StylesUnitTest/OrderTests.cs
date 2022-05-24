namespace Finance.Tests.StylesUnitTest
{
    using FluentAssertions;
    using Xunit;

    public class OrderTests
    {
        [Fact]
        public void ShouldProductBeAdded()
        {
            // Arrange
            var product = new Product("Caneta");

            var sut = new Order();

            // Act
            sut
                .AddProduct(product);

            // Assert
            sut
                .Products
                .Count
                .Should().Be(1);

            //sut.Products[0]
            //BBAssert.Equal(product, sut.Products[0]);
        }
    }
}