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

namespace PavilionAndMalls.Pages.Manager_C.Malls
{
    /// <summary>
    /// Логика взаимодействия для UpadateMalls.xaml
    /// </summary>
    public partial class UpdateMalls : Page
    {
        QueryManagerC Query = new QueryManagerC();

        public UpdateMalls()
        {
            InitializeComponent();
            SearchCity.ItemsSource = QueryManagerC.ListCity();
            SearchMall.ItemsSource = QueryManagerC.ListMalls();
            CRUDCombo.ItemsSource = CRUD.crud;
        }

        private void CRUDCombo_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            switch (CRUDCombo.Text)
            {
                case "Добавить":
                    Add.Visibility = Visibility.Visible;
                    Update.Visibility = SearchMall.Visibility = SearchCity.Visibility = Visibility.Hidden;
                    break;
                case "Изменить":
                    Add.Visibility = Visibility.Hidden;
                    Update.Visibility = SearchMall.Visibility = SearchCity.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Query.AddMall(NameMallTxt.Text, ValueAddedTxt.Text, StatusCmb.Text, BuildCountTxt.Text, CityCmb.Text, ImagePathTxt.Text, FloorTxt.Text, PavilionCountTxt.Text);
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}