using System;
using System.Collections.Generic;
using System.Linq;
using PavilionAndMalls.Data.NewDataForDisplay;
using PavilionAndMalls.EF_Core;

namespace PavilionAndMalls.Pages.Administrators.Employees
{
    public class QueryEmployeesInAdminPage
    {
        public string? FoundSurname(PavilionsContext context)
        {
            var surname = context.Employees
                .Where(s => s.IdEmployee == AdministratorsData.IdEmployee)
                .Select(s => s.Surname).Distinct().FirstOrDefault();
            return surname;
        }

        public string? FoundName(PavilionsContext context)
        {
            var name = context.Employees
                .Where(s => s.IdEmployee == AdministratorsData.IdEmployee)
                .Select(s => s.Name).Distinct().FirstOrDefault();
            return name;
        }

        public string? FoundPatronymic(PavilionsContext context)
        {
            var patronymic = context.Employees
                .Where(s => s.IdEmployee == AdministratorsData.IdEmployee)
                .Select(s => s.Patronymic).Distinct().FirstOrDefault();
            return patronymic;
        }

        public string? FoundLogin(PavilionsContext context)
        {
            var login = context.Employees
                .Where(s => s.IdEmployee == AdministratorsData.IdEmployee)
                .Select(s => s.Login).Distinct().FirstOrDefault();
            return login;
        }

        public string? FoundPassword(PavilionsContext context)
        {
            var passwd = context.Employees
                .Where(s => s.IdEmployee == AdministratorsData.IdEmployee)
                .Select(s => s.Password).Distinct().FirstOrDefault();
            return passwd;
        }

        public string? FoundPhoneNumber(PavilionsContext context)
        {
            var phone = context.Employees
                .Where(s => s.IdEmployee == AdministratorsData.IdEmployee)
                .Select(s => s.PhoneNumber).Distinct().FirstOrDefault();
            return phone;
        }


        public static List<string?> Rolers()
        {
            return App.Context.Roles
                .Select(s => s.RoleName).Distinct().ToList();
        }


        /// <summary>
        /// Поиск по фамилии
        /// </summary>
        /// <param name="Surname"></param>
        /// <returns></returns>
        public List<NewEmployee> SearchOutput(string Surname)
        {
            var context = App.Context;
            var ListEmployees = new List<NewEmployee>();
            var ids = context.Employees
                .Where(s => s.Surname == Surname || s.Surname!.Contains(Surname))
                .Select(s => s).ToList();
            foreach (var id in ids)
            {
                var employee = new NewEmployee
                {
                    Surname = id.Surname,
                    Name = id.Name,
                    Patronymic = id.Patronymic,
                    Login = id.Login,
                    PassWord = id.Password,
                    Role = context.Roles
                    .Where(s => s.IdRole == id.IdRole)
                    .Select(s => s.RoleName).Distinct().FirstOrDefault(),
                    PhoneNumber = id.PhoneNumber
                };
                ListEmployees.Add(employee);
            }

            return ListEmployees;
        }


        public int IdRole(string Role)
        {
            return App.Context.Roles
                .Where(s => s.RoleName == Role)
                .Select(s => s.IdRole).Distinct().FirstOrDefault();
        }


        public void AddEmployee(string Surname, string Name, string Patronymic, string Login, string Password, string Role, string PhoneNumber)
        {
            var context = App.Context;
            int idRole = IdRole(Role);

            var employee = new EF_Core.Employee
            {
                Surname = Surname,
                Name = Name,
                Patronymic = Patronymic,
                Login = Login,
                Password = Password,
                IdRole = idRole,
                PhoneNumber = PhoneNumber
            };
            context.Employees.Add(employee);
            context.SaveChanges();
        }

        public void UpdateEmployee(string Surname, string Name, string Patronymic, string Login, string Password, string Role, string PhoneNumber)
        {
            var context = App.Context;
            int idRole = IdRole(Role);

            var updateemployee = context.Employees
                .Where(s => s.IdEmployee == AdministratorsData.IdEmployee)
                .Select(s => s).Distinct().FirstOrDefault();
            updateemployee!.Surname = Surname;
            updateemployee.Name = Name;
            updateemployee.Patronymic = Patronymic;
            updateemployee.Login = Login;
            updateemployee.Password = Password;
            updateemployee.IdRole = idRole;
            updateemployee.PhoneNumber = PhoneNumber;
            context.SaveChanges();
        }
    }
}