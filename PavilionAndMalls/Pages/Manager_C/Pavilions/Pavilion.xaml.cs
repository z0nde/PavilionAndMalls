using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PavilionAndMalls.Pages.Manager_C
{
    /// <summary>
    /// Логика взаимодействия для ManagerCPavilions.xaml
    /// </summary>
    public partial class Pavilion_ : Page
    {
        public Pavilion_()
        {
            InitializeComponent();
            DGrPavilions.ItemsSource =
                (from p in PavilionsContext.GetContext().Pavilions
                select new { p.IdMall, p.LevelNumber, p.Area, p.IdPavilionStatus, p.ValueAddedFactor, p.SquareMeterCost }).ToList();
        }
    }
}
