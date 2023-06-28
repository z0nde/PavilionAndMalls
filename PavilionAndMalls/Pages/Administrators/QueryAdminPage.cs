using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PavilionAndMalls.Pages.Administrators
{
    public class QueryAdminPage
    {
        public List<string?> SearchSurname(string Surname)
        {
            List<string?> ListSurname = new List<string?>();
            ListSurname = PavilionsContext.GetContext().Employees
                .Where(s => s.Surname == Surname || s.Surname.Contains(Surname))
                .Select(s => s.Surname).Distinct().ToList();
            return ListSurname;
        }
    }
}
