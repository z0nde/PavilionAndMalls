using PavilionAndMalls.Data.NewDataForDisplay;
using PavilionAndMalls.Pages.ManagerC.Malls.Interface.FramesAddUpdateMonitoring.FramesDisplay;
using System.Windows.Controls;
using System.Collections.Generic;

namespace PavilionAndMalls.Pages.ManagerC.Malls.Interface.FramesAddUpdateMonitoring
{
    /// <summary>
    /// Логика взаимодействия для FrameForMonitoringPage.xaml
    /// </summary>
    public partial class FrameForMonitoringPage : Page
    {
        /// <summary>
        /// Обнуление для обновления таблицы Datagrid MonitoringDGr
        /// </summary>
        public void DGRNull() => MonitoringDGr.ItemsSource = null;


        private readonly List<NewMalls> NewMallContext = NewMalls.LoadedData();
        public List<NewMalls> NewMallContextWithFound { get; set; } = new();

        public FrameForMonitoringPage()
        {
            //MonitoringDGr.ItemsSource ??= null;
            InitializeComponent();
            MonitoringDGr.ItemsSource = NewMalls.LoadedData();
        }

        /// <summary>
        /// Событие для поиска названия тц
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FoundNameMall_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (FoundNameMall.Text != null)
            {
                DGRNull();
                MonitoringDGr.ItemsSource = NewMallContextWithFound = QueryMonitoring.FoundMallsName(FoundNameMall.Text);
            }
            else if (FoundNameMall.Text == null)
            {
                MonitoringDGr.ItemsSource = NewMallContextWithFound = NewMallContext;
            }
        }

        /// <summary>
        /// Событие для поиска статуса тц
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FoundMallStatus_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (FoundMallStatus.Text != null)
            {
                DGRNull();
                MonitoringDGr.ItemsSource = NewMallContextWithFound = QueryMonitoring.FoundMallsStatus(FoundMallStatus.Text);
            }
            else if (FoundMallStatus.Text == null)
            {
                MonitoringDGr.ItemsSource = NewMallContextWithFound = NewMallContext;
            }
        }

        /// <summary>
        /// Событие для поиска количества тц
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FoundMallsCount_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (FoundPavilionsCount.Text != null)
            {
                DGRNull();
                MonitoringDGr.ItemsSource = NewMallContextWithFound = QueryMonitoring.FoundPavilionsCount(ConvertWithNullable.ToInt32(FoundPavilionsCount.Text));
            }
            else if (FoundPavilionsCount.Text == null)
            {
                MonitoringDGr.ItemsSource = NewMallContextWithFound = NewMallContext;
            }
        }

        /// <summary>
        /// Событие для поиска города в котором находится тц
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FoundCity_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (FoundCity.Text != null)
            {
                DGRNull();
                MonitoringDGr.ItemsSource = NewMallContextWithFound = QueryMonitoring.FoundCity(FoundCity.Text);
            }
            else if (FoundCity.Text == null)
            {
                MonitoringDGr.ItemsSource = NewMallContextWithFound = NewMallContext;
            }
        }

        /// <summary>
        /// Событие для поиска затрат на строительства тц
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FoundBuildingCost_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (FoundBuildingCost.Text != null)
            {
                DGRNull();
                MonitoringDGr.ItemsSource = NewMallContextWithFound = QueryMonitoring.FoundBuildingCost(ConvertWithNullable.ToDouble(FoundBuildingCost.Text));
            }
            else if (FoundBuildingCost.Text == null)
            {
                MonitoringDGr.ItemsSource = NewMallContextWithFound = NewMallContext;
            }
        }

        /// <summary>
        /// Событие для поиска коэффициента добавочной стоимости тц
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FoundValueAddedFactor_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (FoundValueAddedFactor.Text != null)
            {
                DGRNull();
                MonitoringDGr.ItemsSource = NewMallContextWithFound = QueryMonitoring.FoundValueAddedFactor(ConvertWithNullable.ToDouble(FoundValueAddedFactor.Text));
            }
            else if (FoundValueAddedFactor.Text == null)
            {
                MonitoringDGr.ItemsSource = NewMallContextWithFound = NewMallContext;
            }
        }

        /// <summary>
        /// Событие для поиска количества этажей в тц
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FoundLevelsCount_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (FoundLevelsCount.Text != null)
            {
                DGRNull();
                MonitoringDGr.ItemsSource = NewMallContextWithFound = QueryMonitoring.FoundLevelsCount(ConvertWithNullable.ToInt32(FoundLevelsCount.Text));
            }
            else if (FoundLevelsCount.Text == null)
            {
                MonitoringDGr.ItemsSource = NewMallContextWithFound = NewMallContext;
            }
        }

        private void MonitoringDGr_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }
    }
}