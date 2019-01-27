using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.ObjectModel;
using System.Windows;
using TripApp.Messages;
using TripApp.Models;
using TripApp.Services;

namespace TripApp.ViewModels
{
    class TripListViewModel : ViewModelBase
    {
        private string text = "✔";
        public string Text { get => text; set => Set(ref text, value); }

        private ObservableCollection<Trip> trips;
        public ObservableCollection<Trip> Trips { get => trips; set => Set(ref trips, value); }

        private readonly INavigationService navigationService;
        private readonly AppDbContext db;
        private readonly IMessageService messageService;

        public TripListViewModel(AppDbContext db, IMessageService messageService, INavigationService navigationService)
        {
            this.db = db;
            this.messageService = messageService;
            this.navigationService = navigationService;

            Trips = new ObservableCollection<Trip>(db.Trips);

            Messenger.Default.Register<TripListChangedMessage>(this,
                msg =>
                {
                    Trips.Add(msg.Item);
                });
        }

        private RelayCommand addTripCommand;
        public RelayCommand AddTripCommand
        {
            get => addTripCommand ?? (addTripCommand = new RelayCommand(
                () =>
                {
                    navigationService.Navigate<AddEditTripViewModel>();
                }
            ));
        }

        private RelayCommand<Trip> deleteTripCommand;
        public RelayCommand<Trip> DeleteTripCommand
        {
            get => deleteTripCommand ?? (deleteTripCommand = new RelayCommand<Trip>(
                param =>
                {
                    if (messageService.ShowYesNo("Are you sure?"))
                    {
                        db.Trips.Remove(param);
                        db.SaveChanges();
                        Trips.Remove(param);
                    }
                }
            ));
        }

        private RelayCommand<Trip> editTripCommand;
        public RelayCommand<Trip> EditTripCommand
        {
            get => editTripCommand ?? (editTripCommand = new RelayCommand<Trip>(
                param =>
                {
                    MessageBox.Show("EditCommand");
                }
            ));
        }

        private RelayCommand<Trip> selectTripCommand;
        public RelayCommand<Trip> SelectTripCommand
        {
            get => selectTripCommand ?? (selectTripCommand = new RelayCommand<Trip>(
                param =>
                {
                    if (param.Select == false)
                    {
                        param.Select = true;

                        foreach (var item in db.Trips)
                        {
                            if (item.Name != param.Name)
                                item.Select = false;
                        }
                    }
                }
            ));
        }
    }
}
