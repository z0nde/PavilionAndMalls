using System.Collections.Generic;
using System.Linq;

namespace PavilionAndMalls.Data.NewDataForDisplay
{
    public class NewTenants
    {
        public string? TenantName { get; set; }
        public string? TenantPhone { get; set; }
        public string? TenantAddress { get; set; }
        public string? AdditionalInformation { get; set; }

        public NewTenants(string? tenantName, string? tenantPhone, string? tenantAddress, string? additionalInformation)
        {
            TenantName = tenantName;
            TenantPhone = tenantPhone;
            TenantAddress = tenantAddress;
            AdditionalInformation = additionalInformation;
        }

        public static List<NewTenants> LoadedData()
        {
            List<NewTenants> data = new();
            foreach (var id in App.Context.Tenants.Select(s => s).ToList())
            {
                data.Add(new NewTenants(id.TenantName, id.TenantPhone, id.TenantAddress, id.AdditionalInformation));
            }
            return data;
        }
    }
}