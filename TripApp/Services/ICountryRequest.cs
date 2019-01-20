using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripApp.Services
{
    interface ICountryRequest
    {
        JObject Request(string countryCode);
        string CountryName(JObject data);
        string Currency(JObject data);
        string Language(JObject data);
    }
}
