using PavilionAndMalls.Data;
using PavilionAndMalls.EF_Core;
using System;
using System.Windows;

namespace PavilionAndMalls
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static PavilionsContext Context { get; private set; }
        public App()
        {
            try 
            {
                Context = new PavilionsContext();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
