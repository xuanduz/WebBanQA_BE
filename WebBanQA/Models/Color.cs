using System;
using System.Collections.Generic;

namespace WebBanQA.Models
{
    public partial class Color
    {
        public string ColId { get; set; } = null!;
        public string? ColName { get; set; }
        public string? ColSlug { get; set; }
        public string? ColPid { get; set; }

        public virtual Product? ColP { get; set; }
    }
}
