using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        [Required(ErrorMessage = "Must Enter your Name")]
        public string Name { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Enter your phone number")]
        [RegularExpression(@"^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$"
            , ErrorMessage = "Entered phone format is not valid.")]
        
        public decimal PhnNo { get; set; }

        [Required(ErrorMessage = "Enter your Email")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$"
           , ErrorMessage = "Enter email in proper format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter your UserName")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Enter Password")]
        [MinLength(6, ErrorMessage = "minimum 6 characters required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Re-Enter the Password")]
        [Compare("Password", ErrorMessage = "Password Mismatch")]
        public string Cpassword { get; set; }

        [Required(ErrorMessage = "Enter Bank")]
        public string Bank { get; set; }

        [Required(ErrorMessage = "Enter AccNo")]
        public string AccNo { get; set; }
        [Required(ErrorMessage = "Enter IFSC code")]
        public string IfscCode { get; set; }

        [Required(ErrorMessage = "Enter Dob")]
        public DateTime Dob { get; set; }

        [Required(ErrorMessage = "Enter cardtype")]
        public string Cardtype { get; set; }

        public string ResetPasswordCode { get; set; }
    
        public virtual ICollection<CardStatus> CardStatuses { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }
        public virtual ICollection<TransactionHistory> TransactionHistories { get; set; }
    }
}
