using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PavilionAndMalls.Pages.Authentications
{
    public class QueryAuthentication 
    {
        public int IdRoleInEmployee()
        {
            int? Id = App.Context.Employees
                .Where(s => s.Login == AuthenticationData.Login && s.Password == AuthenticationData.Password)
                .Select(s => s.IdRole).Distinct().FirstOrDefault();

            if (Id != 0)
            {
                AuthenticationData.IdRole = Id;
                return 1;
            }
            else
                return 0;
        }
    }
}