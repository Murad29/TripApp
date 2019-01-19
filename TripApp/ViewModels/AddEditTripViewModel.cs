using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.ComponentModel;
using TripApp.Messages;
using TripApp.Models;
using TripApp.Services;
using WpfAppMVVM.Extensions;

namespace TripApp.ViewModels
{
    class AddEditTripViewModel : ViewModelBase
    {
        private Trip trip = new Trip();
        public Trip Trip { get => trip; set => Set(ref trip, value); }

        private readonly INavigationService navigationService;
        private readonly IMessageService messageService;
        private readonly AppDbContext db;

        public AddEditTripViewModel(INavigationService navigationService, IMessageService messageService, AppDbContext db)
        {
            this.navigationService = navigationService;
            this.messageService = messageService;
            this.db = db;
        }

        private RelayCommand addTripCommand;
        public RelayCommand AddTripCommand
        {
            get => addTripCommand ?? (addTripCommand = new RelayCommand(
                () =>
                {
                    db.Trips.Add(Trip);
                    db.SaveChanges();
                    Messenger.Default.Send(new TripListChangedMessage { Item = Trip });
                    navigationService.Navigate<TripListViewModel>();
                    trip = new Trip();
                }
            ));
        }

        private RelayCommand cancelCommand;
        public RelayCommand CancelCommand
        {
            get => cancelCommand ?? (cancelCommand = new RelayCommand(
                () =>
                {
                    navigationService.Navigate<TripListViewModel>();
                }
            ));
        }
    }
}
