using System;
using System.Collections.Generic;

namespace WebBanQA.Models
{
    public partial class Catalog
    {
        public Catalog()
        {
            Products = new HashSet<Product>();
        }

        public string CaId { get; set; } = null!;
        public string? CaName { get; set; }
        public string? CaStid { get; set; }

        public virtual Style? CaSt { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
