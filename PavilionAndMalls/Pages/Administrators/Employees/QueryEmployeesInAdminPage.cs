using System.Collections.Generic;
using System.Linq;
using PavilionAndMalls.Data.NewDataForDisplay;

namespace PavilionAndMalls.Pages.Administrators.Employees
{
    public class QueryEmployeesInAdminPage
    {
        public string? FoundSurname()
        {
            var surname = PavilionsContext.GetContext().Employees
                .Where(s => s.IdEmployee == AdministratorsData.IdEmployee)
                .Select(s => s.Surname).Distinct().FirstOrDefault();
            return surname;
        }

        public string? FoundName()
        {
            var name = PavilionsContext.GetContext().Employees
                .Where(s => s.IdEmployee == AdministratorsData.IdEmployee)
                .Select(s => s.Name).Distinct().FirstOrDefault();
            return name;
        }

        public string? FoundPatronymic()
        {
            var patronymic = PavilionsContext.GetContext().Employees
                .Where(s => s.IdEmployee == AdministratorsData.IdEmployee)
                .Select(s => s.Patronymic).Distinct().FirstOrDefault();
            return patronymic;
        }

        public string? FoundLogin()
        {
            var login = PavilionsContext.GetContext().Employees
                .Where(s => s.IdEmployee == AdministratorsData.IdEmployee)
                .Select(s => s.Login).Distinct().FirstOrDefault();
            return login;
        }

        public string? FoundPassword()
        {
            var passwd = PavilionsContext.GetContext().Employees
                .Where(s => s.IdEmployee == AdministratorsData.IdEmployee)
                .Select(s => s.Password).Distinct().FirstOrDefault();
            return passwd;
        }

        public string? FoundPhoneNumber()
        {
            var phone = PavilionsContext.GetContext().Employees
                .Where(s => s.IdEmployee == AdministratorsData.IdEmployee)
                .Select(s => s.PhoneNumber).Distinct().FirstOrDefault();
            return phone;
        }


        public static List<string?> Rolers()
        {
            return PavilionsContext.GetContext().Roles
                .Select(s => s.RoleName).Distinct().ToList();
        }


        /// <summary>
        /// Поиск по фамилии
        /// </summary>
        /// <param name="Surname"></param>
        /// <returns></returns>
        public List<NewEmployee> SearchOutput(string Surname)
        {
            List<NewEmployee> ListEmployees = new List<NewEmployee>();
            var ids = PavilionsContext.GetContext().Employees
                .Where(s => s.Surname == Surname || s.Surname.Contains(Surname))
                .Select(s => s).ToList();
            foreach (var id in ids)
            {
                var employee = new NewEmployee();
                employee.Surname = id.Surname;
                employee.Name = id.Name;
                employee.Patronymic = id.Patronymic;
                employee.Login = id.Login;
                employee.PassWord = id.Password;
                employee.Role = PavilionsContext.GetContext().Roles
                    .Where(s => s.IdRole == id.IdRole)
                    .Select(s => s.RoleName).Distinct().FirstOrDefault();
                employee.PhoneNumber = id.PhoneNumber;
                ListEmployees.Add(employee);
            }

            return ListEmployees;
        }


        public int IdRole(string Role)
        {
            return PavilionsContext.GetContext().Roles
                .Where(s => s.RoleName == Role)
                .Select(s => s.IdRole).Distinct().FirstOrDefault();
        }


        public void AddEmployee(string Surname, string Name, string Patronymic, string Login, string Password, string Role, string PhoneNumber)
        {
            int idRole = IdRole(Role);

            var employee = new PavilionAndMalls.Employee
            {
                Surname = Surname,
                Name = Name,
                Patronymic = Patronymic,
                Login = Login,
                Password = Password,
                IdRole = idRole,
                PhoneNumber = PhoneNumber
            };
            PavilionsContext.GetContext().Employees.Add(employee);
            PavilionsContext.GetContext().SaveChanges();
        }

        public void UpdateEmployee(string Surname, string Name, string Patronymic, string Login, string Password, string Role, string PhoneNumber)
        {
            int idRole = IdRole(Role);

            var updateemployee = PavilionsContext.GetContext().Employees
                .Where(s => s.IdEmployee == AdministratorsData.IdEmployee)
                .Select(s => s).Distinct().FirstOrDefault();
            updateemployee.Surname = Surname;
            updateemployee.Name = Name;
            updateemployee.Patronymic = Patronymic;
            updateemployee.Login = Login;
            updateemployee.Password = Password;
            updateemployee.IdRole = idRole;
            updateemployee.PhoneNumber = PhoneNumber;
            PavilionsContext.GetContext().SaveChanges();
        }
    }
}
