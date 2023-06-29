using PavilionAndMalls.Pages.Authentications;
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
                AuthenticationValidation QueryAcc = new AuthenticationValidation(Login.Text, Password.Text);
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
                    AuthenticationValidation QueryAcc = new AuthenticationValidation(Login.Text, Password.Text);
                    QueryAcc.Controller();
                }
                Capcha.Content = Pages.Authentications.Capcha.Make();
            }
        }
        private void Password_PasswordChanged(object sender, RoutedEventArgs e)
        {

        }

        private void PasswdVisible_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
