using System;
using System.Collections.Generic;

namespace WebBanQA.Models
{
    public partial class Cart
    {
        public Cart()
        {
            Cartdeta = new HashSet<Cartdetum>();
        }

        public string CarId { get; set; } = null!;
        public string? CarUid { get; set; }
        public string CarSelect { get; set; } = null!;
        public string CarStatus { get; set; } = null!;
        public DateTime? CarDate { get; set; }

        public virtual User? CarU { get; set; }
        public virtual ICollection<Cartdetum> Cartdeta { get; set; }
    }
}
