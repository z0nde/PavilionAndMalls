using System;
using System.Collections.Generic;

namespace PavilionAndMalls.Data.NewDataForDisplay
{
    public class NewTenants
    {
        public string? MallName { get; set; }
        public string? City { get; set; }
        public string? NumberPavilion { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public double CostOfTenant { get; set; }

        /*public List<NewEmployee> LoadedData()
        {
            var ListEmployee = new List<NewEmployee>();

        }*/
    }
}
