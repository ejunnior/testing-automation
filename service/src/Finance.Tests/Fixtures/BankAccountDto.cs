namespace Finance.Tests.Fixtures
{
    using System.ComponentModel.DataAnnotations;

    public class BankAccountDto
    {
        [MaxLength(80)]
        public string AccountNumber { get; set; }

        public int Id { get; set; }
    }
}