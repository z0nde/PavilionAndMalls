using System;
using System.Collections.Generic;

namespace PavilionAndMalls.EF_Core
{
    public partial class PavilionsTenant
    {
        public int IdPavilonTenant { get; set; }
        public int? IdTenant { get; set; }
        public int? IdMall { get; set; }
        public int? IdEmployee { get; set; }
        public int? IdPavilion { get; set; }
        public DateTime? RentStart { get; set; }
        public DateTime? RentEnd { get; set; }

        public virtual Employee? IdEmployeeNavigation { get; set; }
        public virtual Mall? IdMallNavigation { get; set; }
        public virtual Pavilion? IdPavilionNavigation { get; set; }
        public virtual Tenant? IdTenantNavigation { get; set; }
    }
}
