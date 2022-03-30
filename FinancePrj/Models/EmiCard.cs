using System;
using System.Collections.Generic;

#nullable disable

namespace FinancePrj.Models
{
    public partial class EmiCard
    {
        public string Cardtype { get; set; }
        public decimal? CardLimit { get; set; }
        public int? ProcessingFee { get; set; }
    }
}
