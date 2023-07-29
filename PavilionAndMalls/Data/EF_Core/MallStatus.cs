using System;
using System.Collections.Generic;

namespace PavilionAndMalls
{
    public partial class MallStatus
    {
        public MallStatus()
        {
            Malls = new HashSet<Mall>();
        }

        public int IdMallStatus { get; set; }
        public string? MallStatus1 { get; set; }

        public virtual ICollection<Mall> Malls { get; set; }
    }
}
