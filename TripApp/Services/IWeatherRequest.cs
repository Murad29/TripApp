using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripApp.Services
{
    interface IWeatherRequest
    {
        JObject Request(string cityName);
        string CountryCode(JObject data);
        string CurrentWeather(JObject data);
    }
}
