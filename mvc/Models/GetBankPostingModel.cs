namespace FrontEnd.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class GetBankPostingModel
    {
        [DisplayFormat(DataFormatString = "{0:#,#.00}")]
        public decimal Amount { get; set; }

        public string Creditor { get; set; }

        public string Description { get; set; }

        public DateTime? DocumentDate { get; set; }

        public string DocumentNumber { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DueDate { get; set; }

        public int Id { get; set; }

        public DateTime? PaymentDate { get; set; }
    }
}