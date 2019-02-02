using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WpfAppMVVM.Extensions;

namespace TripApp.Models
{
    public class Ticket : ObservableObject, IDataErrorInfo
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string TicketName{ get; set; }
        [Required]
        public string TicketSource { get; set; }

        public int? TicketId { get; set; }
        public Trip TripName { get; set; }

        public string Error => throw new NotImplementedException();

        public string this[string columnName] => this.Validate(columnName);
    }
}
