namespace Finance.Tests.Fixtures
{
    using AutoFixture;

    public class CreditorDtoFixture
    {
        private readonly CreditorDto _dto;

        public CreditorDtoFixture()
        {
            var fixture = new Fixture();

            _dto = fixture
                .Create<CreditorDto>();
        }

        public CreditorDto Build()
        {
            return _dto;
        }
    }
}