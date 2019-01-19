using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TripApp.ViewModels;
using TripApp.Views;

namespace TripApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var locator = new ViewModelLocator();

            var window = new MainWindowView { DataContext = locator.GetMainWindowViewModel() }.ShowDialog();
        }
    }
}
