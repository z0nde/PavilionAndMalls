using PavilionAndMalls.Data.NewDataForDisplay;
using System.Windows.Controls;

namespace PavilionAndMalls.Pages.ManagerA
{
    /// <summary>
    /// Логика взаимодействия для ManagerA.xaml
    /// </summary>
    public partial class ManagerA : Page
    {
        public ManagerA()
        {
            InitializeComponent();
            DGrPayback.ItemsSource = PaybackMalls.LoadedData();
        }
    }
}