using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripApp.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string TicketName{ get; set; }
        [Required]
        public string TicketSource { get; set; }

        public int? TicketId { get; set; }
        public Trip TripName { get; set; }
    }
}
