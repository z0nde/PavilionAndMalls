using System;
using System.Collections.Generic;

namespace PavilionAndMalls.EF_Core
{
    public partial class Pavilion
    {
        public Pavilion()
        {
            PavilionsTenants = new HashSet<PavilionsTenant>();
        }

        public int IdPavilion { get; set; }
        public string? PavilionNumber { get; set; }
        public int? IdMall { get; set; }
        public int? LevelNumber { get; set; }
        public int? IdPavilionStatus { get; set; }
        public double? Area { get; set; }
        public double? SquareMeterCost { get; set; }
        public double? ValueAddedFactor { get; set; }

        public virtual Mall? IdMallNavigation { get; set; }
        public virtual PavilionStatus? IdPavilionStatusNavigation { get; set; }
        public virtual ICollection<PavilionsTenant> PavilionsTenants { get; set; }
    }
}
