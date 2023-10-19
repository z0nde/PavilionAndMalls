using PavilionAndMalls.Pages.ManagerC.Malls.Interface.FramesDisplay;
using System.Windows;
using System.Windows.Controls;

namespace PavilionAndMalls.Pages.ManagerC.Malls.Interface.FramesAddUpdate
{
    /// <summary>
    /// Логика взаимодействия для FrameForAddPage.xaml
    /// </summary>
    public partial class FrameForAddPage : Page
    {
        public FrameForAddPage()
        {
            InitializeComponent();
            MallStatusCmb.ItemsSource = Collections.Statuses;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            QueryAddUpdate queryAdd = new (MallNameTxt.Text, ValueAddedFactorTxt.Text, MallStatusCmb.Text, BuildingCostTxt.Text, CityTxt.Text, Photo.Text, LevelsCountTxt.Text, PavilionsCountTxt.Text);
            queryAdd.AddMall();
        }
    }
}