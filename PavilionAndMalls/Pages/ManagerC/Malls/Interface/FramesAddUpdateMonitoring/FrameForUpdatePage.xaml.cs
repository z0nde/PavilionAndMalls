using PavilionAndMalls.Data.NewDataForDisplay;
using PavilionAndMalls.Pages.ManagerC.Malls.Interface.FramesDisplay;
using System.Windows;
using System.Windows.Controls;

namespace PavilionAndMalls.Pages.ManagerC.Malls.Interface.FramesAddUpdate
{
    /// <summary>
    /// Логика взаимодействия для FrameForUpdatePage.xaml
    /// </summary>
    public partial class FrameForUpdatePage : Page
    {
        public FrameForUpdatePage()
        {
            InitializeComponent();
        }

        public FrameForUpdatePage(NewMalls newMalls)
        {
            InitializeComponent();
            MallNameTxt.Text = newMalls.MallName;
            MallStatusCmb.Text = newMalls.MallStatus;
            PavilionsCountTxt.Text = newMalls.PavilionsCount.ToString();
            CityTxt.Text = newMalls.City;
            BuildingCostTxt.Text = newMalls.BuildingCost.ToString();
            ValueAddedFactorTxt.Text = newMalls.ValueAddedFactor.ToString();
            LevelsCountTxt.Text = newMalls.LevelsCount.ToString();
            Photo.Text = newMalls.MallPhoto.ToString();
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            QueryAddUpdate queryUpdate = new(MallNameTxt.Text, ValueAddedFactorTxt.Text, MallStatusCmb.Text, BuildingCostTxt.Text, CityTxt.Text, Photo.Text, LevelsCountTxt.Text, PavilionsCountTxt.Text);
            queryUpdate.UpdateMall();
        }
    }
}
