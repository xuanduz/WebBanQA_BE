using System;
using System.Collections.Generic;

namespace WebBanQA.Models
{
    public partial class Cartdetum
    {
        public string CdId { get; set; } = null!;
        public string? CdPid { get; set; }
        public string? CdCarId { get; set; }
        public string? CdColslug { get; set; }
        public string? CdSName { get; set; }
        public int? CdAmount { get; set; }

        public virtual Cart? CdCar { get; set; }
        public virtual Product? CdP { get; set; }
    }
}
