using System;
using System.Collections.Generic;

#nullable disable

namespace FinancePrj.Models
{
    public partial class Admin
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public decimal? MobNo { get; set; }
    }
}
