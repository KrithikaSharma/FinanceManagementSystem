using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace FinancePrj.Models
{
    public partial class Customer
    {
        public Customer()
        {
            BankDetails = new HashSet<BankDetail>();
            Purchases = new HashSet<Purchase>();
            TransactionHistories = new HashSet<TransactionHistory>();
        }

        public int CusNo { get; set; }
        public string Name { get; set; }
        public decimal? PhnNo { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Cardtype { get; set; }
        public int? Status { get; set; }
        public DateTime? Validity { get; set; }
        public decimal? CardBalance { get; set; }

        public virtual ICollection<BankDetail> BankDetails { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }
        public virtual ICollection<TransactionHistory> TransactionHistories { get; set; }
    }
}
