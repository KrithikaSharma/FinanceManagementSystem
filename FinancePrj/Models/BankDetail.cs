using System;
using System.Collections.Generic;

#nullable disable

namespace FinancePrj.Models
{
    public partial class BankDetail
    {
        public int? CusNo { get; set; }
        public string Bank { get; set; }
        public string AccNo { get; set; }
        public string IfscCode { get; set; }
        public DateTime? Dob { get; set; }

        public virtual Customer CusNoNavigation { get; set; }
    }
}
