using System;
using TechTalk.SpecFlow;

namespace Finance.Tests.Category
{
    [Binding]
    public class CategorySteps
    {
        [Given(@"I have a new category")]
        public void GivenIHaveANewCategory()
        {
            // Configurar o nosso teste
        }

        [Then(@"the category should be created")]
        public void ThenTheCategoryShouldBeCreated()
        {
            // Asserts
        }

        [When(@"fill up the category information")]
        public void WhenFillUpTheCategoryInformation()
        {
            // Executar
        }
    }
}