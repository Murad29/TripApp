using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using TripApp.Messages;
using TripApp.Models;
using TripApp.Services;

namespace TripApp.ViewModels
{
    public class TicketListViewModel : ViewModelBase
    {
        private Ticket ticket;
        public Ticket Ticket { get => ticket; set => Set(ref ticket, value); }

        private Trip selectedTrip;
        public Trip SelectedTrip { get => selectedTrip; set => Set(ref selectedTrip, value); }

        private ObservableCollection<Ticket> tickets;
        public ObservableCollection<Ticket> Tickets { get => tickets; set => Set(ref tickets, value); }

        private readonly INavigationService navigationService;
        private readonly AppDbContext db;
        private readonly IMessageService messageService;

        public TicketListViewModel(AppDbContext db, IMessageService messageService, INavigationService navigationService)
        {
            Tickets = null;

            foreach (var item in db.Trips)
            {
                if(item.Select.Value)
                    selectedTrip = item;
            }

            this.db = db;
            this.messageService = messageService;
            this.navigationService = navigationService;

            var result = db.Tickets.Where(t => t.TripName.Id == selectedTrip.Id).ToList();
            Tickets = new ObservableCollection<Ticket>(result);
                        
            Messenger.Default.Register<TicketListChangedMessage>(this,
                msg =>
                {
                    Tickets.Add(msg.Item);
                });
        }

        private RelayCommand<string> addTicketCommand;
        public RelayCommand<string> AddTicketCommand
        {
            get => addTicketCommand ?? (addTicketCommand = new RelayCommand<string>(
                param =>
                {
                    navigationService.Navigate<AddTicketViewModel>();
                }
            ));
        }

        private RelayCommand<Ticket> deleteTicketCommand;
        public RelayCommand<Ticket> DeleteTicketCommand
        {
            get => deleteTicketCommand ?? (deleteTicketCommand = new RelayCommand<Ticket>(
                param =>
                {
                    param.TripName = SelectedTrip;

                    if (messageService.ShowYesNo("Are you sure?"))
                    {
                        db.Tickets.Remove(param);
                        db.SaveChanges();
                        Tickets.Remove(param);
                    }
                }
            ));
        }

        private RelayCommand<Ticket> showTicketCommand;
        public RelayCommand<Ticket> ShowTicketCommand
        {
            get => showTicketCommand ?? (showTicketCommand = new RelayCommand<Ticket>(
                param =>
                {
                    navigationService.Navigate<ShowTicketViewModel>();
                    Messenger.Default.Send(new TicketListChangedMessage { Item = param });
                }
            ));
        }
    }
}
