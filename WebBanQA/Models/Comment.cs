using System;
using System.Collections.Generic;

namespace WebBanQA.Models
{
    public partial class Comment
    {
        public string ComId { get; set; } = null!;
        public string? ComContent { get; set; }
        public string? ComUid { get; set; }
        public string? ComPid { get; set; }

        public virtual Product? ComP { get; set; }
        public virtual User? ComU { get; set; }
    }
}
