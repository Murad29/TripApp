using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using TripApp.Services;

namespace TripApp.ViewModels
{
    class MenuViewModel : ViewModelBase
    {
        private readonly INavigationService navigation;

        public MenuViewModel(INavigationService navigation) => this.navigation = navigation;

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
