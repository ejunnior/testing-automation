namespace Finance.Tests.StylesUnitTest
{
    using Moq;
    using Xunit;

    public class OrderServiceTests
    {
        [Fact]
        public void ShouldOrderBePayedByCreditCard()
        {
            // Arrange
            var order = new Order();

            var payPalMock = new Mock<IPayPal>();

            var sut = new OrderService(payPalMock.Object);

            // Act
            sut.Checkout(order);

            // Assert
            payPalMock.Verify(x => x.CreditCardPayment());
        }
    }
}