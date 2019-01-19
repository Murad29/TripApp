using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripApp.Models;

namespace TripApp.Messages
{
    class TripListChangedMessage
    {
        public Trip Item { get; set; }
    }
}
