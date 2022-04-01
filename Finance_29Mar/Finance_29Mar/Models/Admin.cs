using System;
using System.Collections.Generic;

#nullable disable

namespace Finance_29Mar.Models
{
    public partial class Admin
    {
        public Admin()
        {
            CardStatuses = new HashSet<CardStatus>();
        }

        public int Aid { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public decimal? MobNo { get; set; }

        public virtual ICollection<CardStatus> CardStatuses { get; set; }
    }
}
