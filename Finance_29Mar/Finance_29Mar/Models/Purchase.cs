using System;
using System.Collections.Generic;

#nullable disable

namespace Finance_29Mar.Models
{
    public partial class Purchase
    {
        public int BookingId { get; set; }
        public int ProdId { get; set; }
        public int? CusNo { get; set; }
        public int? EmiScheme { get; set; }
        public DateTime? PurchasedDate { get; set; }
        public decimal? DueAmount { get; set; }
        public decimal? MonthlyAmount { get; set; }

        public virtual Customer CusNoNavigation { get; set; }
        public virtual Product Prod { get; set; }
    }
}
