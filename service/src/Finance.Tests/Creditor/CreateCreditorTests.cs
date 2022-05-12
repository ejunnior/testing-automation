namespace Finance.Tests.Creditor
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using Xunit;

    public class CreateCreditorTests
    {
        private const string PageUrl = "http://localhost:4200/";
        private readonly IWebDriver _webDriver;

        public CreateCreditorTests()
        {
            _webDriver = new ChromeDriver();
        }

        [Fact]
        private void ShouldCreditorBeCreated()
        {
            // Arrange
            _webDriver.Navigate().GoToUrl(PageUrl);

            _webDriver.FindElement(By.Id("creditor")).Click();

            _webDriver.FindElement(By.Id("create")).Click();

            _webDriver.FindElement(By.Id("name")).SendKeys("Creditor Name");

            _webDriver.FindElement(By.Id("create")).Click();

            // Act

            // Assert
        }
    }
}