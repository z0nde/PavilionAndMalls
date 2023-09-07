using PavilionAndMalls.Data.NewDataForDisplay;
using PavilionAndMalls.Pages.Manager_C.Pavilion;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PavilionAndMalls.Pages.Manager_C
{
    /// <summary>
    /// Логика взаимодействия для ManagerCPavilions.xaml
    /// </summary>
    public partial class Pavilion_ : Page
    {
        QueryPavilionsPages Query = new QueryPavilionsPages();

        public Pavilion_()
        {
            InitializeComponent();
            DGrPavilions.ItemsSource = NewPavilions.LoadedData();
            StatusPavilionCombo.ItemsSource = Query.Statuses();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Query.AddPavilion(NumberFloorTxt.Text, PavilionCodeTxt.Text, AreaTxt.Text, StatusPavilionCombo.Text, VAFTxt.Text, MSQTxt.Text);
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Query.UpdatePavilion(NumberFloorTxt.Text, PavilionCodeTxt.Text, AreaTxt.Text, StatusPavilionCombo.Text, VAFTxt.Text, MSQTxt.Text);
        }

        private void DGrPavilions_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ManagerCData.IdPavilions = DGrPavilions.SelectedIndex + 1;
            NumberFloorTxt.Text = QueryPavilionsPages.FoundFloor();
            //PavilionCodeTxt.Text = Query.FoundPavilionCode();
            AreaTxt.Text = Query.FoundArea();
            VAFTxt.Text = Query.FoundVAF();
            MSQTxt.Text = Query.FoundMeterSquareCost();
        }
    }
}
