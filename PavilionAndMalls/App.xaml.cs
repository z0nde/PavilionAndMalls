using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PavilionAndMalls
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static PavilionsContext context { get; private set; }
        public App()
        {
            try 
            {
                context = PavilionsContext.GetContext();
            }
            catch 
            {
                
            }
        }
    }
}
