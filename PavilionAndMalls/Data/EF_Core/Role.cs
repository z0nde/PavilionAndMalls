using System;
using System.Collections.Generic;

namespace PavilionAndMalls
{
    public partial class Role
    {
        public Role()
        {
            Employees = new HashSet<Employee>();
        }

        public int IdRole { get; set; }
        public string? RoleName { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
