namespace Finance.Tests.Fixtures
{
    using AutoFixture;

    public class RegisterPayableDtoFixture
    {
        private RegisterPayableDto _dto;

        public RegisterPayableDtoFixture()
        {
            var fixture = new Fixture();

            _dto = fixture
                .Create<RegisterPayableDto>();
        }

        public RegisterPayableDto Build()
        {
            return _dto;
        }

        public RegisterPayableDtoFixture WithAmount(decimal amount)
        {
            _dto.Amount = amount;
            return this;
        }

        public RegisterPayableDtoFixture WithBankAccountId(int bankAccountId)
        {
            _dto.BankAccountId = bankAccountId;
            return this;
        }

        public RegisterPayableDtoFixture WithCategoryId(int categoryId)
        {
            _dto.CategoryId = categoryId;
            return this;
        }

        public RegisterPayableDtoFixture WithCreditorId(int creditorId)
        {
            _dto.CreditorId = creditorId;
            return this;
        }
    }
}