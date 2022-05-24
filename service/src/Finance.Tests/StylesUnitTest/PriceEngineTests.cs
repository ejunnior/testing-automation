namespace Finance.Tests.StylesUnitTest
{
    using FluentAssertions;
    using Xunit;

    public class PriceEngineTests
    {
        [Fact]
        public void ShouldDiscountBeCalculated() // Estilo funcinal...
        {
            // Arrange
            var product1 = new Product("Caneta");
            var product2 = new Product("Lapis");

            var sut = new PriceEngine();

            // Act
            var discount = sut
                .CalculateDiscount(product1, product2);

            // Assert
            discount
                .Should()
                .Be(0.02M);
        }
    }
}