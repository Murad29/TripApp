using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WpfAppMVVM.Extensions;

namespace TripApp.Models
{
    public class Trip : ObservableObject, IDataErrorInfo
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public DateTime DepartureDate { get; set; } = DateTime.Now;
        //[CurrentDate(ErrorMessage = "Date must be after or equal to current date")]
        public DateTime ArrivalDate { get; set; } = DateTime.Now;

        public IEnumerable<Ticket> Tickets { get; set; }

        private bool? select = false;
        public bool? Select { get => select; set => Set(ref select, value); }

        public string Error => throw new NotImplementedException();

        public string this[string columnName] => this.Validate(columnName);
    }
}
