using System;
using System.Collections.Generic;

#nullable disable

namespace FinancePrj.Models
{
    public partial class TransactionHistory
    {
        public int TrnId { get; set; }
        public DateTime? Date { get; set; }
        public decimal? Amount { get; set; }
        public int? CusNo { get; set; }
        public int? PrdId { get; set; }

        public virtual Customer CusNoNavigation { get; set; }
        public virtual Product Prd { get; set; }
    }
}
