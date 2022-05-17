namespace Finance.Tests.PageObject
{
    using OpenQA.Selenium;

    public class HomePage
    {
        private const string PageUrl = "http://localhost:4200/";
        private readonly IWebDriver _webDriver;

        public HomePage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public CreditorListPage ClickCreditorLink()
        {
            _webDriver
                .FindElement(By.Id("creditor")).Click();

            return new CreditorListPage(_webDriver);
        }

        public void NavigateTo()
        {
            _webDriver
                .Navigate()
                .GoToUrl(PageUrl);
        }
    }
}