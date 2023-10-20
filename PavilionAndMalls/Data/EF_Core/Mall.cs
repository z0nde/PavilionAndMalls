using System;
using System.Collections.Generic;

namespace PavilionAndMalls.EF_Core
{
    public partial class Mall
    {
        public Mall()
        {
            Pavilions = new HashSet<Pavilion>();
            PavilionsTenants = new HashSet<PavilionsTenant>();
        }

        public int IdMall { get; set; }
        public string? MallName { get; set; }
        public int? IdMallStatus { get; set; }
        public int? PavilionsCount { get; set; }
        public int? IdCity { get; set; }
        public double? BuildingCost { get; set; }
        public double? ValueAddedFactor { get; set; }
        public int? LevelsCount { get; set; }
        public byte[]? MallPicture { get; set; }

        public virtual City? IdCityNavigation { get; set; }
        public virtual MallStatus? IdMallStatusNavigation { get; set; }
        public virtual ICollection<Pavilion> Pavilions { get; set; }
        public virtual ICollection<PavilionsTenant> PavilionsTenants { get; set; }
    }
}
