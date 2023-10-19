using PavilionAndMalls.Data.NewDataForDisplay;
using PavilionAndMalls.Data.NewDataForDisplay.ListsNewData;
using PavilionAndMalls.Pages.ManagerC.Malls.List;
using PavilionAndMalls.Pages.ManagerC.Pavilions;
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
        private static List<NewMalls> NewMallsList { get; set; } = NewMalls.LoadedData();
        private void LBoMallsItemsSourceNull() => LBoMalls.ItemsSource = null;

        public MallList()
        {
            InitializeComponent();
            LBoMallsItemsSourceNull();
            LBoMalls.ItemsSource ??= ListNewMalls.NewMalls;
            SortCityCmb.ItemsSource ??= Collections.SortItemsForCombo;
            SortStatusCmb.ItemsSource ??= Collections.SortItemsForCombo;
            SelectStatusCmb.ItemsSource ??= MallListAddons.GetStatusExDel();
        }

        private void LBoMalls_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int count = NewMallsList
                .Where(s => s.NumberMall == LBoMalls.SelectedIndex)
                .Select(s => s.IdMall).FirstOrDefault();
            FrameManager.MainFrame.Navigate(new PavilionsListInterface(count));
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
                NewMallsList = NewMalls.LoadedData();
                NewMallsList = ListNewMalls.NewMalls
                    .OrderBy(s => s.City)
                    .Select(s => s).ToList();
                NewMallsList = ListNewMalls.ReNumber(NewMallsList);
                LBoMalls.ItemsSource = NewMallsList;
            }
            else if (SortCityCmb.Text == Collections.SortItemsForCombo[1])
            {
                LBoMallsItemsSourceNull();
                NewMallsList = NewMalls.LoadedData();
                NewMallsList = ListNewMalls.NewMalls
                    .OrderByDescending(s => s.City)
                    .Select(s => s).ToList();
                NewMallsList = ListNewMalls.ReNumber(NewMallsList);
                LBoMalls.ItemsSource = NewMallsList;
            }
        }

        private void SortStatusCmb_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (SortStatusCmb.Text == Collections.SortItemsForCombo[0])
            {
                LBoMallsItemsSourceNull();
                SelectStatusCmb.Text = null;
                NewMallsList = NewMalls.LoadedData();
                NewMallsList = ListNewMalls.NewMalls
                    .OrderBy(s => s.IdMallStatus)
                    .Select(s => s).ToList();
                NewMallsList = ListNewMalls.ReNumber(NewMallsList);
                LBoMalls.ItemsSource = NewMallsList;
            }
            else if (SortStatusCmb.Text == Collections.SortItemsForCombo[1])
            {
                LBoMallsItemsSourceNull();
                SelectStatusCmb.Text = null;
                NewMallsList = NewMalls.LoadedData();
                NewMallsList = ListNewMalls.NewMalls
                    .OrderByDescending(s => s.IdMallStatus)
                    .Select(s => s).ToList();
                NewMallsList = ListNewMalls.ReNumber(NewMallsList);
                LBoMalls.ItemsSource = NewMallsList;
            }
        }

        private void SelectStatusCmb_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            List<string> list = new(MallListAddons.GetStatusExDel());
            if (SelectStatusCmb.Text == list[0])
            {
                LBoMallsItemsSourceNull();
                SortStatusCmb.Text = null;
                NewMallsList = NewMalls.LoadedData();
                NewMallsList = ListNewMalls.NewMalls
                    .Where(s => s.MallStatus == list[0])
                    .Select(s => s).ToList();
                NewMallsList = ListNewMalls.ReNumber(NewMallsList);
                LBoMalls.ItemsSource = NewMallsList;
            }
            else if (SelectStatusCmb.Text == list[1])
            {
                LBoMallsItemsSourceNull();
                SortStatusCmb.Text = null;
                NewMallsList = NewMalls.LoadedData();
                NewMallsList = ListNewMalls.NewMalls
                    .Where(s => s.MallStatus == list[1])
                    .Select(s => s).ToList();
                NewMallsList = ListNewMalls.ReNumber(NewMallsList);
                LBoMalls.ItemsSource = NewMallsList;
            }
            else if (SelectStatusCmb.Text == list[2])
            {
                LBoMallsItemsSourceNull();
                SortStatusCmb.Text = null;
                NewMallsList = NewMalls.LoadedData();
                NewMallsList = ListNewMalls.NewMalls
                    .Where(s => s.MallStatus == list[2])
                    .Select(s => s).ToList();
                NewMallsList = ListNewMalls.ReNumber(NewMallsList);
                LBoMalls.ItemsSource = NewMallsList;
            }
        }
    }
}