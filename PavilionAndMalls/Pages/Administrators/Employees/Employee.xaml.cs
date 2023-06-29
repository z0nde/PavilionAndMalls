using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using PavilionAndMalls.Pages.Administrators.Employees;

namespace PavilionAndMalls.Pages.Administrators
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Employee : Page
    {
        QueryEmployeesInAdminPage Query = new QueryEmployeesInAdminPage();

        public Employee()
        {
            InitializeComponent();
            DGrEmployees.ItemsSource = NewEmployee.LoadedData();
            RoleCombo.ItemsSource = QueryEmployeesInAdminPage.Rolers();
        }

        private void SearchSurname_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SearchSurname.Text != "")
            {
                DGrEmployees.ItemsSource = Query.SearchOutput(SearchSurname.Text);
            }
            else if (SearchSurname.Text == "")
            {
                DGrEmployees.ItemsSource = NewEmployee.LoadedData();
            }
        }

        private void DGrEmployees_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            AdministratorsData.IdEmployee = DGrEmployees.SelectedIndex + 1;
            SurnameTxt.Text = Query.FoundSurname();
            NameTxt.Text = Query.FoundName();
            PatronymicTxt.Text = Query.FoundPatronymic();
            LoginTxt.Text = Query.FoundLogin();
            PasswdTxt.Text = Query.FoundPassword();
            PhonenumberTxt.Text = Query.FoundPhoneNumber();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Query.AddEmployee(SurnameTxt.Text, NameTxt.Text, PatronymicTxt.Text, LoginTxt.Text, PasswdTxt.Text, RoleCombo.Text, PhonenumberTxt.Text);
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Query.UpdateEmployee(SurnameTxt.Text, NameTxt.Text, PatronymicTxt.Text, LoginTxt.Text, PasswdTxt.Text, RoleCombo.Text, PhonenumberTxt.Text);
        }

        private void PasswdTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            PasswordSecurity Check = new PasswordSecurity();
            CheckPasswd.Content = Check.CheckPassword(PasswdTxt.Text);
        }
    }
}
