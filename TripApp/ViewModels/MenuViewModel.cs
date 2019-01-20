using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TripApp.Services;

namespace TripApp.ViewModels
{
    class MenuViewModel : ViewModelBase
    {
        private readonly INavigationService navigation;

        public MenuViewModel(INavigationService navigation)
        {
            this.navigation = navigation;
        }

        private RelayCommand<Type> navigateCommand;
        public RelayCommand<Type> NavigateCommand
        {
            get => navigateCommand ?? (navigateCommand = new RelayCommand<Type>(
                param =>
                {
                    navigation.Navigate(param);
                }
            ));
        }
    }
}
