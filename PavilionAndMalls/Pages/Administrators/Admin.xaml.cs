using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PavilionAndMalls.Pages.Administrators
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Page
    {
        QueryAdminPage Query = new QueryAdminPage();
        public static int IdEmployee { get; set; }

        public Admin()
        {
            InitializeComponent();
            DGrEmployees.ItemsSource =
                (from s in PavilionsContext.GetContext().Employees
                 select new { s.Surname, s.Name, s.Patronymic, s.Login, s.Password, s.IdRole, s.PhoneNumber }).ToList();
        }

        private void SearchSurname_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SearchSurname.Text == "")
            {
                Query.SearchSurname(SearchSurname.Text);
                DGrEmployees.ItemsSource =
                    (from s in PavilionsContext.GetContext().Employees
                     select new { s.Surname, s.Name, s.Patronymic, s.Login, s.Password, s.IdRole, s.PhoneNumber }).ToList();
            }
        }

        private void DGrEmployees_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            IdEmployee = DGrEmployees.SelectedIndex + 1;

        }
    }
}
