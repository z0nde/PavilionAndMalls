using System.Windows;
using System.Windows.Controls;

namespace PavilionAndMalls.Pages.Administrators
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();
        }

        private void GoToEmployee_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new Employee());
        }

        private void GoToOutTenants_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new AdditionalInformation.OutputTenant());
        }

        private void GoToAddTenants_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new AdditionalInformation.AddTenant());
        }
    }
}
