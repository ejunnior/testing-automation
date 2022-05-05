namespace Finance.Tests.Fixtures
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class RegisterPayableDto
    {
        public decimal Amount { get; set; }

        public int BankAccountId { get; set; }

        public int CategoryId { get; set; }

        public int CreditorId { get; set; }

        [MaxLength(80)]
        public string Description { get; set; }

        public DateTime DocumentDate { get; set; }

        [MaxLength(20)]
        public string DocumentNumber { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime PaymentDate { get; set; }
    }
}