using PavilionAndMalls.Data.NewDataForDisplay;
using PavilionAndMalls.Pages.ManagerC.Malls.List;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PavilionAndMalls.Pages.Manager_C.Malls
{
    /// <summary>
    /// Логика взаимодействия для MallList.xaml
    /// </summary>
    public partial class MallList : Page
    {
        private void LBoMallsItemsSourceNull() => LBoMalls.ItemsSource = null;

        public MallList()
        {
            InitializeComponent();
            LBoMallsItemsSourceNull();
            LBoMalls.ItemsSource ??= NewMalls.LoadedData();
            SortCityCmb.ItemsSource ??= Collections.SortItemsForCombo;
            SortStatusCmb.ItemsSource ??= Collections.SortItemsForCombo;
            SelectStatusCmb.ItemsSource ??= MallListAddons.GetStatusExDel();
        }

        private void LBoMalls_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ManagerCData.IdMalls = LBoMalls.SelectedIndex + 1;
            FrameManager.MainFrame.Navigate(new Pavilion_());
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new MallInterface());
        }

        private void SortCityCmb_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (SortCityCmb.Text == Collections.SortItemsForCombo[0])
            {
                LBoMallsItemsSourceNull();
                LBoMalls.ItemsSource = NewMalls.LoadedData()
                    .OrderBy(s => s.City)
                    .Select(s => s);
            }
            else if (SortCityCmb.Text == Collections.SortItemsForCombo[1])
            {
                LBoMallsItemsSourceNull();
                LBoMalls.ItemsSource = NewMalls.LoadedData()
                    .OrderByDescending(s => s.City)
                    .Select(s => s);
            }
        }

        private void SortStatusCmb_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (SortStatusCmb.Text == Collections.SortItemsForCombo[0])
            {
                LBoMallsItemsSourceNull();
                SelectStatusCmb.Text = null;
                LBoMalls.ItemsSource = NewMalls.LoadedData()
                    .OrderBy(s => s.IdMallStatus)
                    .Select(s => s);
            }
            else if (SortStatusCmb.Text == Collections.SortItemsForCombo[1])
            {
                LBoMallsItemsSourceNull();
                SelectStatusCmb.Text = null;
                LBoMalls.ItemsSource = NewMalls.LoadedData()
                    .OrderByDescending(s => s.IdMallStatus)
                    .Select(s => s);
            }
        }

        private void SelectStatusCmb_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            List<string> list = new(MallListAddons.GetStatusExDel());
            if (SelectStatusCmb.Text == list[0])
            {
                LBoMallsItemsSourceNull();
                SortStatusCmb.Text = null;
                LBoMalls.ItemsSource = NewMalls.LoadedData()
                    .Where(s => s.MallStatus == list[0])
                    .Select(s => s);
            }
            else if (SelectStatusCmb.Text == list[1])
            {
                LBoMallsItemsSourceNull();
                SortStatusCmb.Text = null;
                LBoMalls.ItemsSource = NewMalls.LoadedData()
                    .Where(s => s.MallStatus == list[1])
                    .Select(s => s);
            }
            else if (SelectStatusCmb.Text == list[2])
            {
                LBoMallsItemsSourceNull();
                SortStatusCmb.Text = null;
                LBoMalls.ItemsSource = NewMalls.LoadedData()
                    .Where(s => s.MallStatus == list[2])
                    .Select(s => s);
            }
        }
    }
}