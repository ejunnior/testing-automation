namespace Finance.Application.Bank
{
    using Domain.Core;

    public class GetBankAccountDto
    {
        public string AccountNumber { get; set; }
        public int Id { get; set; }
    }
}