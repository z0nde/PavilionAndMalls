using System;
using System.Collections.Generic;

namespace PavilionAndMalls
{
    public partial class City
    {
        public City()
        {
            Malls = new HashSet<Mall>();
        }

        public int IdCity { get; set; }
        public string? CityName { get; set; }

        public virtual ICollection<Mall> Malls { get; set; }
    }
}
