using System;
using TechTalk.SpecFlow;

namespace Finance.Tests.Category
{
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Fixtures;
    using FluentAssertions;
    using Infrastructure;
    using Infrastructure.Api;
    using Microsoft.AspNetCore.Mvc;

    [Binding]
    public class CategorySteps : ControllerBaseTest<FixtureBase>
    {
        private CategoryDto _dto;
        private StringContent _model;

        public CategorySteps(FixtureBase fixture)
            : base(fixture)
        {
        }

        private string Path => "api/v1/category";

        [Given(@"I have a new category")]
        public void GivenIHaveANewCategory()
        {
            _dto = new CategoryDtoFixture()
               .Build();
        }

        [Then(@"the category should be created")]
        public async Task ThenTheCategoryShouldBeCreated()
        {
            var response = await HttpClient.PostAsync(
                requestUri: GetUri(path: $"{Path}"),
                content: _model);

            response
                .StatusCode
                .Should()
                .Be(HttpStatusCode.OK);
        }

        [When(@"fill up the category information")]
        public void WhenFillUpTheCategoryInformation()
        {
            var json = JsonSerializer
                .Serialize(_dto);

            _model = new StringContent(
                json, Encoding.UTF8, "application/json");
        }
    }
}