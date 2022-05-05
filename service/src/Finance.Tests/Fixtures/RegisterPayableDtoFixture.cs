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

        //Metodos para setar valores especificos
    }
}