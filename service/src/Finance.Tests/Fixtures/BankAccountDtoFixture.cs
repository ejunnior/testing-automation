namespace Finance.Tests.Fixtures
{
    using AutoFixture;

    public class BankAccountDtoFixture
    {
        private readonly BankAccountDto _dto;

        public BankAccountDtoFixture()
        {
            var fixture = new Fixture();

            _dto = fixture
                .Create<BankAccountDto>();
        }

        public BankAccountDto Build()
        {
            return _dto;
        }
    }
}