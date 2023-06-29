using System.Windows;

namespace PavilionAndMalls.Pages.Authentications
{
    /// <summary>
    /// Класс предназначен для логики взимодействия со страницей аутентификации
    /// </summary>
    public class AuthenticationValidation
    {
        QueryAuthentication Query = new QueryAuthentication();
        public AuthenticationValidation()
        {

        }

        /// <summary>
        /// Конструктор для класса, принимающий логин и пароль, и записывающий аргументы в свойства 
        /// класса с данными аутентификации
        /// </summary>
        /// <param name="Login"></param>
        /// <param name="Passwd"></param>
        public AuthenticationValidation(string Login, string Passwd)
        {
            AuthenticationData.Login = Login;
            AuthenticationData.Password = Passwd;
        }

        /// <summary>
        /// Метод контроллера, который переносит на нужную страницу в зависимости от роли аккаунта
        /// либо выдающий счётчик на капчу
        /// </summary>
        public void Controller()
        {
            if (Query.IdRoleInEmployee() != 0)
            {
                if (AuthenticationData.IdRole == 1)
                {
                    FrameManager.MainFrame.Navigate(new Administrators.Employee());
                    AuthenticationData.AttemptsCaptcha = 0;
                }
                else if (AuthenticationData.IdRole == 2)
                {
                    AuthenticationData.AttemptsCaptcha = 0;
                }
                else if (AuthenticationData.IdRole == 3)
                {
                    FrameManager.MainFrame.Navigate(new ManagerC.ManagerC());
                    AuthenticationData.AttemptsCaptcha = 0;
                }
                else if (AuthenticationData.IdRole == 4)
                {
                    //AuthenticationData.AttemptsCaptcha = 0;
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль");
                    AuthenticationData.AttemptsCaptcha++;
                }
            }
        }
    }
}