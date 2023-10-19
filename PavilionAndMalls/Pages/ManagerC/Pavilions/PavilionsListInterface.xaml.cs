using PavilionAndMalls.Data.NewDataForDisplay;
using PavilionAndMalls.Data.NewDataForDisplay.ListsNewData;
using PavilionAndMalls.Pages.Manager_C.Pavilion;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PavilionAndMalls.Pages.ManagerC.Pavilions
{
    /// <summary>
    /// Логика взаимодействия для PavilionsListInterface.xaml
    /// </summary>
    public partial class PavilionsListInterface : Page
    {
        private void DGrNull() => DGrPavilions.ItemsSource = null;

        public static List<NewPavilions> NewPavilionsList { get; set; } = NewPavilions.LoadedData();


        private readonly QueryPavilionsPages Query = new();


        public PavilionsListInterface()
        {
            InitializeComponent();
            //DGrPavilions.ItemsSource = NewPavilions.LoadedData();
            StatusPavilionCombo.ItemsSource = Query.Statuses();
        }

        public PavilionsListInterface(int idMall)
        {
            InitializeComponent();
            DGrNull();
            NewPavilionsList = ListNewPavilions.NewPavilions
                .Where(s => s.IdMall == idMall)
                .Select(s => s).ToList();
            NewPavilionsList = ListNewPavilions.ReNumber(NewPavilionsList);
            DGrPavilions.ItemsSource = NewPavilionsList;
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
            NewPavilions pavilions = Query.GetListForAddUpdate(NewPavilionsList, DGrPavilions.SelectedIndex - 1);
            NumberFloorTxt.Text = pavilions.NumberFloor.ToString();
            PavilionCodeTxt.Text = pavilions.PavilionCode;
            AreaTxt.Text = pavilions.Area.ToString();
            VAFTxt.Text = pavilions.ValueAddFacktor.ToString();
            MSQTxt.Text = pavilions.MeterSquareCost.ToString();
        }
    }
}