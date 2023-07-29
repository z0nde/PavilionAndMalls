using System;
using System.Collections.Generic;

namespace PavilionAndMalls
{
    public partial class PavilionStatus
    {
        public PavilionStatus()
        {
            Pavilions = new HashSet<Pavilion>();
        }

        public int IdPavilionStatus { get; set; }
        public string? PavilionStatus1 { get; set; }

        public virtual ICollection<Pavilion> Pavilions { get; set; }
    }
}
