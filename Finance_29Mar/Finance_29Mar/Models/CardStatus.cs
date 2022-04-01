using System;
using System.Collections.Generic;

#nullable disable

namespace Finance_29Mar.Models
{
    public partial class CardStatus
    {
        public int CardNo { get; set; }
        public int? Adminid { get; set; }
        public int? CusNo { get; set; }
        public int? Status { get; set; }
        public DateTime? Validity { get; set; }
        public decimal? CardBalance { get; set; }
        public string Cardtype { get; set; }

        public virtual Admin Admin { get; set; }
        public virtual Customer CusNoNavigation { get; set; }
    }
}
