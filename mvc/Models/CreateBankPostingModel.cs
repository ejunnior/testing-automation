namespace FrontEnd.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class CreateBankPostingModel
    {
        [Required]
        public decimal Amount { get; set; }

        public IList<SelectListItem> BankAccount { get; set; }

        [Required]
        public int BankAccountId { get; set; }

        public IList<SelectListItem> Category { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public IList<SelectListItem> Creditor { get; set; }

        [Required]
        public int CreditorId { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime? DocumentDate { get; set; }

        public string DocumentNumber { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        public DateTime? PaymentDate { get; set; }

        [Required]
        public int Type { get; set; }
    }
}