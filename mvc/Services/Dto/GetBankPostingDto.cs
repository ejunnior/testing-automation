namespace FrontEnd.Services.Dto
{
    using System;

    public class GetBankPostingDto
    {
        public decimal Amount { get; set; }

        public string Creditor { get; set; }

        public string Description { get; set; }

        public DateTime? DocumentDate { get; set; }

        public string DocumentNumber { get; set; }

        public DateTime DueDate { get; set; }

        public int Id { get; set; }

        public DateTime? PaymentDate { get; set; }
    }
}