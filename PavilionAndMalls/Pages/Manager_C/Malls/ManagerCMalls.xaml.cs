using PavilionAndMalls.Pages.Manager_C;
using PavilionAndMalls.Pages.Manager_C.Malls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PavilionAndMalls.Pages.ManagerC
{
    /// <summary>
    /// Логика взаимодействия для ManagerC.xaml
    /// </summary>
    public partial class ManagerC : Page
    {
        public ManagerC()
        {
            InitializeComponent();
            LBoMalls.ItemsSource = NewMalls.LoadedData();
        }

        private void LBoMalls_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ManagerCData.IdMalls = LBoMalls.SelectedIndex + 1;
            FrameManager.MainFrame.Navigate(new Pavilion_());
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new UpdateMalls());
        }
    }
}