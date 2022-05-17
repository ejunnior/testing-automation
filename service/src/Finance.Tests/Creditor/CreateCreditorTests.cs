namespace Finance.Tests.Creditor
{
    using Fixtures;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using PageObject;
    using Xunit;

    public class CreateCreditorTests
    {
        [Fact]
        private void ShouldCreditorBeCreated()
        {
            using (var webDriver = new ChromeDriver())
            {
                // Arrange

                var homePage = new HomePage(webDriver);

                homePage
                    .NavigateTo();

                var creditor = new CreditorDtoFixture()
                    .Build();

                // Act

                homePage
                    .ClickCreditorLink()
                    .ClickCreateLink()
                    .EnterCreditorName(creditor.CreditorName)
                    .ClickCreateLink();

                // Assert
            }
        }
    }
}