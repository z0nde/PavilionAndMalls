using System;
using System.Collections.Generic;

namespace PavilionAndMalls
{
    public partial class Tenant
    {
        public Tenant()
        {
            PavilionsTenants = new HashSet<PavilionsTenant>();
        }

        public int IdTenant { get; set; }
        public string? TenantName { get; set; }
        public string? TenantPhone { get; set; }
        public string? TenantAddress { get; set; }

        public virtual ICollection<PavilionsTenant> PavilionsTenants { get; set; }
    }
}
