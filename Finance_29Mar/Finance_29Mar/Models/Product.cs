using System;
using System.Collections.Generic;

#nullable disable

namespace Finance_29Mar.Models
{
    public partial class Product
    {
        public Product()
        {
            Purchases = new HashSet<Purchase>();
            TransactionHistories = new HashSet<TransactionHistory>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Image { get; set; }
        public int? Qty { get; set; }
        public string Description { get; set; }
        public decimal? ProductCost { get; set; }
        public decimal? StrikedCost { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }
        public virtual ICollection<TransactionHistory> TransactionHistories { get; set; }
    }
}
