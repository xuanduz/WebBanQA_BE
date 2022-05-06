using System;
using System.Collections.Generic;

namespace WebBanQA.Models
{
    public partial class Style
    {
        public Style()
        {
            Catalogs = new HashSet<Catalog>();
        }

        public string StId { get; set; } = null!;
        public string? StName { get; set; }
        public string? StSlug { get; set; }

        public virtual ICollection<Catalog> Catalogs { get; set; }
    }
}
