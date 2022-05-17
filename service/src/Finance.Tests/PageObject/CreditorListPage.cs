namespace Finance.Tests.PageObject
{
    using OpenQA.Selenium;

    public class CreditorListPage
    {
        private readonly IWebDriver _webDriver;

        public CreditorListPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public CreditorCreatePage ClickCreateLink()
        {
            _webDriver
                .FindElement(By.Id("create")).Click();

            return new CreditorCreatePage(_webDriver);
        }
    }
}