using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.Windows;
using TripApp.Messages;
using TripApp.Models;
using TripApp.Services;

namespace TripApp.ViewModels
{
    class AddEditTicketViewModel : ViewModelBase
    {
        private Ticket ticket = new Ticket();
        public Ticket Ticket { get => ticket; set => Set(ref ticket, value); }

        private string ticketSource;
        public string TicketSource { get => ticketSource; set => Set(ref ticketSource, value); }

        private Trip selectedTrip;
        public Trip SelectedTrip { get => selectedTrip; set => Set(ref selectedTrip, value); }

        private readonly INavigationService navigationService;
        private readonly IMessageService messageService;
        private readonly AppDbContext db;

        public AddEditTicketViewModel(INavigationService navigationService, IMessageService messageService, AppDbContext db)
        {
            this.navigationService = navigationService;
            this.messageService = messageService;
            this.db = db;

            foreach (var item in db.Trips)
            {
                if (item.Select.Value)
                    selectedTrip = item;
            }
        }

        private RelayCommand addSourceCommand;
        public RelayCommand AddSourceTripCommand
        {
            get => addSourceCommand ?? (addSourceCommand = new RelayCommand(
                () =>
                {
                    navigationService.Navigate<AddEditTicketViewModel>();
                    Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog
                    {
                        DefaultExt = ".pdf",
                        Filter = "Pdf Files|*.pdf"
                    };

                    bool? result = dlg.ShowDialog();

                    if (result == true)
                        TicketSource = Ticket.TicketSource = dlg.FileName;

                    MessageBox.Show(Ticket.TicketSource);
                }
            ));
        }

        private RelayCommand addTripCommand;
        public RelayCommand AddTripCommand
        {
            get => addTripCommand ?? (addTripCommand = new RelayCommand(
                () =>
                {
                    Ticket.TripName = selectedTrip;
                    db.Tickets.Add(Ticket);
                    db.SaveChanges();
                    Messenger.Default.Send(new TicketListChangedMessage { Item = Ticket });
                    navigationService.Navigate<TicketListViewModel>();
                    ticket = new Ticket();
                }
            ));
        }

        private RelayCommand cancelCommand;
        public RelayCommand CancelCommand
        {
            get => cancelCommand ?? (cancelCommand = new RelayCommand(
                () =>
                {
                    navigationService.Navigate<TicketListViewModel>();
                }
            ));
        }
    }
}
