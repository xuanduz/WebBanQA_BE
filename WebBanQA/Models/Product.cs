using System;
using System.Collections.Generic;

namespace WebBanQA.Models
{
    public partial class Product
    {
        public Product()
        {
            Cartdeta = new HashSet<Cartdetum>();
            Colors = new HashSet<Color>();
            Comments = new HashSet<Comment>();
            Sizes = new HashSet<Size>();
        }

        public string PId { get; set; } = null!;
        public string? PName { get; set; }
        public double? PDiscount { get; set; }
        public decimal? PPrice { get; set; }
        public string? PImage { get; set; }
        public string? PNote { get; set; }
        public int? PAmount { get; set; }
        public string? PContent { get; set; }
        public string? PCaid { get; set; }
        public string? PSlug { get; set; }

        public virtual Catalog? PCa { get; set; }
        public virtual ICollection<Cartdetum> Cartdeta { get; set; }
        public virtual ICollection<Color> Colors { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Size> Sizes { get; set; }
    }
}
