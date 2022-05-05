namespace Finance.Tests.Fixtures
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class GetPayableDto
    {
        public decimal Amount { get; set; }
        public int BankAccountId { get; set; }
        public int CategoryId { get; set; }
        public int CreditorId { get; set; }
        public string Description { get; set; }
        public DateTime DocumentDate { get; set; }
        public string DocumentNumber { get; set; }
        public DateTime DueDate { get; set; }
        public int Id { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}