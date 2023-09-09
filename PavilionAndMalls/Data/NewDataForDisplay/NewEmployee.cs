using System.Collections.Generic;
using System.Linq;

namespace PavilionAndMalls.Data.NewDataForDisplay
{
    public class NewEmployee
    {
        public string? Surname { get; set; }
        public string? Name { get; set; }
        public string? Patronymic { get; set; }
        public string? Login { get; set; }
        public string? PassWord { get; set; }
        public string? Role { get; set; }
        public string? PhoneNumber { get; set; }

        public static List<NewEmployee> LoadedData()
        {
            List<NewEmployee> ListEmployees = new List<NewEmployee>();
            var context = App.Context;
            var ids = context.Employees.Select(s => s).ToList();
            foreach (var id in ids)
            {
                var employee = new NewEmployee();
                employee.Surname = id.Surname;
                employee.Name = id.Name;
                employee.Patronymic = id.Patronymic;
                employee.Login = id.Login;
                employee.PassWord = id.Password;
                employee.Role = context.Roles
                    .Where(s => s.IdRole == id.IdRole)
                    .Select(s => s.RoleName).Distinct().FirstOrDefault();
                employee.PhoneNumber = id.PhoneNumber;
                ListEmployees.Add(employee);
            }

            return ListEmployees;
        }
    }
}
