using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace TripApp.Services
{
    class CountryRequest : ICountryRequest
    {
        private WebClient WebClient = new WebClient();

        private string currencyCode;
        private string language;
       // private static readonly string CountrieApiUrl = @"https://restcountries.eu/rest/v2/alpha";

        public string CountryName(JObject data) => data["name"].ToString();

        public string Currency(JObject data)
        {
            foreach (var item in data["currencies"])
                currencyCode = item["code"].ToString();

            return currencyCode;
        }

        public string Language(JObject data)
        {
            foreach (var item in data["languages"])
                language = item["name"].ToString();

            return language;
        }

        public JObject Request(string countryCode)
        {
            string request = $"https://restcountries.eu/rest/v2/alpha/{countryCode}";
            string response = WebClient.DownloadString(request);
            JObject data = JObject.Parse(response);

            return data;
        }
    }
}
