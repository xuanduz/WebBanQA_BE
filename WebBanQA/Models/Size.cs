using System;
using System.Collections.Generic;

namespace WebBanQA.Models
{
    public partial class Size
    {
        public string SId { get; set; } = null!;
        public string? SName { get; set; }
        public string? SPid { get; set; }

        public virtual Product? SP { get; set; }
    }
}
