﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.ObjectModel;
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
            this.db = db;
            this.messageService = messageService;
            this.navigationService = navigationService;

            Tickets = new ObservableCollection<Ticket>(db.Tickets);

            Messenger.Default.Register<TicketListChangedMessage>(this,
                msg =>
                {
                    Tickets.Add(msg.Item);
                });

            foreach (var item in db.Trips)
            {
                if(item.Select.Value)
                    selectedTrip = item;
            }
        }

        private RelayCommand<string> addTicketCommand;
        public RelayCommand<string> AddTicketCommand
        {
            get => addTicketCommand ?? (addTicketCommand = new RelayCommand<string>(
                param =>
                {
                    navigationService.Navigate<AddEditTicketViewModel>();
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
    }
}