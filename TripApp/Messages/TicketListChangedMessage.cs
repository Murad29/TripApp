using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripApp.Models;

namespace TripApp.Messages
{
    class TicketListChangedMessage
    {
        public Ticket Item { get; set; }
    }
}
