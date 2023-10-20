using System;
using System.Collections.Generic;

namespace PavilionAndMalls.EF_Core
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
        public string? AdditionalInformation { get; set; }

        public virtual ICollection<PavilionsTenant> PavilionsTenants { get; set; }
    }
}
