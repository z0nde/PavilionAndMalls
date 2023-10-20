using PavilionAndMalls.Data.NewDataForDisplay;
using System.Windows.Controls;

namespace PavilionAndMalls.AdditionalInformation
{
    /// <summary>
    /// Логика взаимодействия для OutputTenant.xaml
    /// </summary>
    public partial class OutputTenant : Page
    {
        public OutputTenant()
        {
            InitializeComponent();
            DGrTennants.ItemsSource = NewTenants.LoadedData();
        }
    }
}
