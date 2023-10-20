using System;
using System.Collections.Generic;

namespace PavilionAndMalls.EF_Core
{
    public partial class Log
    {
        public string? CurrentUser { get; set; }
        public int? RentId { get; set; }
        public string? TenantName { get; set; }
        public string? EmployeeLastName { get; set; }
        public string? CenterName { get; set; }
        public int? PavilionId { get; set; }
        public int? StatusId { get; set; }
        public DateTime? RentalStart { get; set; }
        public DateTime? RentalEnd { get; set; }
    }
}
