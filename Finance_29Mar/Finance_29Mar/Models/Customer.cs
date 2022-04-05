using System;
using System.Collections.Generic;

#nullable disable

namespace Finance_29Mar.Models
{
    public partial class Customer
    {
        public Customer()
        {
            CardStatuses = new HashSet<CardStatus>();
            Purchases = new HashSet<Purchase>();
            TransactionHistories = new HashSet<TransactionHistory>();
        }

        public int CusNo { get; set; }
        public string Name { get; set; }
        public decimal PhnNo { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Cpassword { get; set; }
        public string Bank { get; set; }
        public string AccNo { get; set; }
        public string IfscCode { get; set; }
        public DateTime Dob { get; set; }
        public string Cardtype { get; set; }
        public string ResetPasswordCode { get; set; }

        public virtual ICollection<CardStatus> CardStatuses { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }
        public virtual ICollection<TransactionHistory> TransactionHistories { get; set; }
    }
}
