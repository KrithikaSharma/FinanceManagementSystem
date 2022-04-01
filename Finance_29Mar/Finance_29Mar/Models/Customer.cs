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

        [Required(ErrorMessage = "Name cannot be blank")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Phone Number cannot be blank")]
        [Display(Name = "Phone Number")]
        [RegularExpression("/[0-9]{10}")]
        public decimal? PhnNo { get; set; }

        [Required(ErrorMessage = "Email cannot be blank")]
        [RegularExpression("/^[a-z0-9][-a-z0-9._]+@([-a-z0-9]+.)+[a-z]{2,5}$"
           , ErrorMessage = "Enter email in proper format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Username cannot be blank")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password cannot be blank")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password cannot be blank")]
        [Display(Name = "Confirm Password")]
        [Compare("Password"
            , ErrorMessage = "Passwords should be same in password and confirm password")]
        public string Cpassword { get; set; }

        [Required(ErrorMessage = "Bank name cannot be blank")]
        public string Bank { get; set; }

        [Required(ErrorMessage = "Account Number cannot be blank")]
        public string AccNo { get; set; }

        [Required(ErrorMessage = "IFSC Code cannot be blank")]
        public string IfscCode { get; set; }

        [Required(ErrorMessage = "Date of birth cannot be blank")]
        public DateTime? Dob { get; set; }

        [Required(ErrorMessage = "Cardtype has to be selected")]
        public string Cardtype { get; set; }

        public virtual ICollection<CardStatus> CardStatuses { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }
        public virtual ICollection<TransactionHistory> TransactionHistories { get; set; }
    }
}
