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
            var categoryDto = new CategoryDtoFixture()
                .Build();

            var categoryPersisted = await Connection
                .CreateCategoryAsync(categoryDto);

            var creditorDto = new CreditorDtoFixture()
                .Build();

            var creditorPersisted = await Connection
                .CreateCreditorAsync(creditorDto);

            var bankAccountDto = new BankAccountDtoFixture()
                .Build();

            var bankAccountPersisted = await Connection
                .CreateBankAccountAsync(bankAccountDto);

            var dto = new RegisterPayableDtoFixture()
                .WithCategoryId(categoryPersisted.Id)
                .WithCreditorId(creditorPersisted.Id)
                .WithBankAccountId(bankAccountPersisted.Id)
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
                .BeEquivalentTo(dto, e => e.Excluding(p => p.Id));
        }

        [Fact]
        public async Task PayableAccountShouldBeUpdated()
        {
            // Arrange
            var categoryDto = new CategoryDtoFixture()
                .Build();

            var categoryPersisted = await Connection
                .CreateCategoryAsync(categoryDto);

            var creditorDto = new CreditorDtoFixture()
                .Build();

            var creditorPersisted = await Connection
                .CreateCreditorAsync(creditorDto);

            var bankAccountDto = new BankAccountDtoFixture()
                .Build();

            var bankAccountPersisted = await Connection
                .CreateBankAccountAsync(bankAccountDto);

            var payableDto = new RegisterPayableDtoFixture()
                .WithCategoryId(categoryPersisted.Id)
                .WithCreditorId(creditorPersisted.Id)
                .WithBankAccountId(bankAccountPersisted.Id)
                .Build();

            var payablePersisted = await Connection
                .CreatePayableAsync(payableDto);

            categoryDto = new CategoryDtoFixture()
                .Build();

            categoryPersisted = await Connection
                .CreateCategoryAsync(categoryDto);

            creditorDto = new CreditorDtoFixture()
                .Build();

            creditorPersisted = await Connection
                .CreateCreditorAsync(creditorDto);

            bankAccountDto = new BankAccountDtoFixture()
                .Build();

            bankAccountPersisted = await Connection
                .CreateBankAccountAsync(bankAccountDto);

            var dto = new RegisterPayableDtoFixture()
                .WithCategoryId(categoryPersisted.Id)
                .WithCreditorId(creditorPersisted.Id)
                .WithBankAccountId(bankAccountPersisted.Id)
                .Build();

            var json = JsonSerializer
                .Serialize(dto);

            var data = new StringContent(
                json, Encoding.UTF8, "application/json");

            // Act
            await HttpClient.PutAsync(
                requestUri: GetUri(path: $"{Path}/{payablePersisted.Id}"),
                content: data);

            // Assert
            var persisted = await Connection
                .GetPayableByDocumentNumberAsync(dto.DocumentNumber);

            persisted
                .Should()
                .BeEquivalentTo(dto, e => e.Excluding(p => p.Id));
        }
    }
}