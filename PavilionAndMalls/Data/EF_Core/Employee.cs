using System;
using System.Collections.Generic;

namespace PavilionAndMalls.EF_Core
{
    public partial class Employee
    {
        public Employee()
        {
            PavilionsTenants = new HashSet<PavilionsTenant>();
        }

        public int IdEmployee { get; set; }
        public string? Surname { get; set; }
        public string? Name { get; set; }
        public string? Patronymic { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public int? IdRole { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Gender { get; set; }
        public byte[]? EmployeePhoto { get; set; }

        public virtual Role? IdRoleNavigation { get; set; }
        public virtual ICollection<PavilionsTenant> PavilionsTenants { get; set; }
    }
}
