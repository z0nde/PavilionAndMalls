using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using PavilionAndMalls.Data.NewDataForDisplay;
using PavilionAndMalls.Pages.ManagerC.Malls.Interface.FramesAddUpdate;
using PavilionAndMalls.Pages.ManagerC.Malls.Interface.FramesAddUpdateMonitoring;

namespace PavilionAndMalls.Pages.Manager_C.Malls
{
    /// <summary>
    /// Логика взаимодействия для MallInterface.xaml
    /// </summary>
    public partial class MallInterface : Page
    {
        private static List<NewMalls> NewMallsWithFoundInMonitoringPage { get; set; } = new();

        public MallInterface()
        {
            InitializeComponent();
            MainPageFrame.Navigate(new FrameForMonitoringPage());
            FrameManager.MainFramePageMonitoring = MainPageFrame;
            MonitoringBtnToUpdatePageInFrame.Background = new SolidColorBrush(Colors.LightSteelBlue);
        }

        public MallInterface(List<NewMalls> newMalls)
        {
            NewMallsWithFoundInMonitoringPage = newMalls;
        }

        private void AddBtnToUpdatePageInFrame_Click(object sender, RoutedEventArgs e)
        {
            AddBtnToUpdatePageInFrame.Background = new SolidColorBrush(Colors.LightSteelBlue);
            UpdateBtnToUpdatePageInFrame.Background = MonitoringBtnToUpdatePageInFrame.Background = new SolidColorBrush(Colors.AliceBlue);
            MainPageFrame.Navigate(new FrameForAddPage());
        }

        private void UpdateBtnToUpdatePageInFrame_Click(object sender, RoutedEventArgs e)
        {
            AddBtnToUpdatePageInFrame.Background = MonitoringBtnToUpdatePageInFrame.Background = new SolidColorBrush(Colors.AliceBlue);
            UpdateBtnToUpdatePageInFrame.Background = new SolidColorBrush(Colors.LightSteelBlue);
            MainPageFrame.Navigate(new FrameForUpdatePage());
        }

        private void MonitoringBtnToUpdatePageInFrame_Click(object sender, RoutedEventArgs e)
        {
            AddBtnToUpdatePageInFrame.Background = UpdateBtnToUpdatePageInFrame.Background = new SolidColorBrush(Colors.AliceBlue);
            MonitoringBtnToUpdatePageInFrame.Background = new SolidColorBrush(Colors.LightSteelBlue);
            MainPageFrame.Navigate(new FrameForMonitoringPage());
        }
    }
}