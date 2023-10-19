using PavilionAndMalls.Pages.Authentications;
using System;
using System.Windows;
using System.Windows.Controls;

namespace PavilionAndMalls
{
    /// <summary>
    /// Логика взаимодействия для Authentication.xaml
    /// </summary>
    public partial class Authentication : Page
    {
        public Authentication()
        {
            InitializeComponent();
            InputCapcha.Visibility = Visibility.Hidden;
            Capcha.Visibility = Visibility.Hidden;
            Capcha.Content = Pages.Authentications.Capcha.Make();
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {

            if (AuthenticationData.AttemptsCaptcha < 3)
            {
                AuthenticationValidation QueryAcc = new(Login.Text, Password.Text);
                QueryAcc.Controller();                
            }
            else 
            {
                Capcha.Visibility = Visibility.Visible;
                InputCapcha.Visibility = Visibility.Visible;

                if (InputCapcha.Text == Capcha.Content.ToString())
                {
                    Capcha.Visibility = Visibility.Hidden;
                    InputCapcha.Visibility = Visibility.Hidden;
                    AuthenticationValidation QueryAcc = new(Login.Text, Password.Text);
                    QueryAcc.Controller();
                }
                Capcha.Content = Pages.Authentications.Capcha.Make();
            }
        }
        private void PasswdVisible_Click(object sender, RoutedEventArgs e)
        {
            /*PasswordTextChanged.Click++;
            if (PasswordTextChanged.Click % 2 == 0)
            {
                Password.Text = PasswordTextChanged.Visiblpassword();
            }
            else if (PasswordTextChanged.Click % 2 != 0)
            {
                PasswordTextChanged ptc = new PasswordTextChanged(Password.Text);
                Password.Text = ptc.HidingPassword();
            }*/
        }

        private void Password_TextChanged(object sender, TextChangedEventArgs e)
        {
            /*PasswordTextChanged.CountChar = Convert.ToUInt16(Password.Text.Length);
            if (PasswordTextChanged.Click % 2 == 0)
            {
                Password.Text = PasswordTextChanged.Visiblpassword();
            }
            else if (PasswordTextChanged.Click % 2 != 0)
            {
                PasswordTextChanged ptc = new PasswordTextChanged(Password.Text);
                Password.Text = ptc.HidingPassword();
            }*/
        }

        private void GoToManageC_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new Pages.Manager_C.Malls.MallList());
        }

        private void GoToOdmen_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new Pages.Administrators.AdminPage());
        }
    }
}
