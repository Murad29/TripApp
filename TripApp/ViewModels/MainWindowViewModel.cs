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
    class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase currentPage;
        public ViewModelBase CurrentPage { get => currentPage; set => Set(ref currentPage, value); }

        private readonly INavigationService navigation;

        public MainWindowViewModel(INavigationService navigation)
        {
            this.navigation = navigation;

            Messenger.Default.Register<ViewModelBase>(this, viewModel => CurrentPage = viewModel);
        }

        private RelayCommand openMenuCommand;
        public RelayCommand OpenMenuCommand
        {
            get => openMenuCommand ?? (openMenuCommand = new RelayCommand(
                () =>
                {
                    navigation.Navigate<MenuViewModel>();
                }
            ));
        }
    }
}
