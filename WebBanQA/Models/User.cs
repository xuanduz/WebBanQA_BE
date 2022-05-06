using System;
using System.Collections.Generic;

namespace WebBanQA.Models
{
    public partial class User
    {
        public User()
        {
            Carts = new HashSet<Cart>();
            Comments = new HashSet<Comment>();
        }

        public string UId { get; set; } = null!;
        public string? UFname { get; set; }
        public string? ULname { get; set; }
        public string UEmail { get; set; } = null!;
        public string UStatus { get; set; } = null!;
        public string? UAdd { get; set; }
        public string UName { get; set; }
        public string? UContact { get; set; }
        public DateTime? UCreated { get; set; }
        public string? UPass { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
