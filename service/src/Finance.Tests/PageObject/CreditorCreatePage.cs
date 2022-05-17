namespace Finance.Tests.PageObject
{
    using OpenQA.Selenium;

    public class CreditorCreatePage
    {
        private readonly IWebDriver _webDriver;

        public CreditorCreatePage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public CreditorListPage ClickCreateLink()
        {
            _webDriver
                .FindElement(By.Id("create")).Click();

            return new CreditorListPage(_webDriver);
        }

        public CreditorCreatePage EnterCreditorName(string name)
        {
            _webDriver
                .FindElement(By.Id("name"))
                .SendKeys(name);

            return this;
        }
    }
}