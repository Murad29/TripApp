using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripApp.Models
{
    public class City
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public string CountryName { get; set; }
        public string Currency { get; set; }
        public string Language { get; set; }
        public string CurrentWeather { get; set; }
    }
}
