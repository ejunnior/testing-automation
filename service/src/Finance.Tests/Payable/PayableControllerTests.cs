namespace Finance.Tests.Payable
{
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Fixtures;
    using Infrastructure;
    using Infrastructure.Api;
    using System.Text.Json;
    using Xunit;
    using System.Net.Http.Json;
    using FluentAssertions;

    public class PayableControllerTests
        : ControllerBaseTest<FixtureBase>
    {
        public PayableControllerTests(FixtureBase fixture)
            : base(fixture)
        {
        }

        private string Path => "api/v1/payable";

        [Fact]
        public async Task PayableAccountShouldBeCreated()
        {
            // Arrange

            //Dto e autofixture -- Category / BanAccount / Creditor

            var dto = new RegisterPayableDtoFixture()
                //.WithCreditorId()
                //.WithBankAccountId()
                //.WithCreditorId()
                .Build();

            var json = JsonSerializer
                .Serialize(dto);

            var data = new StringContent(
                json, Encoding.UTF8, "application/json");

            // Act
            await HttpClient.PostAsync(
                requestUri: GetUri(path: $"{Path}"),
                content: data);

            // Assert

            var persisted = await Connection
                .GetPayableByDocumentNumberAsync(dto.DocumentNumber);

            persisted
                .Should()
                .Be(dto);
        }
    }
}