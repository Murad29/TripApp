using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripApp.Models;

namespace TripApp.Messages
{
    class CityListChangedMessage
    {
        public City Item { get; set; }
    }
}
