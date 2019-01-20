using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TripApp.Services
{
    class WeatherRequest : IWeatherRequest
    {
        private readonly WebClient webClient = new WebClient();

        private static readonly string weatherApiKey = "85fffe48ba19b9f6d46556b00c4ffae3";
        private static readonly string weatherApiUrl = @"https://api.openweathermap.org/data/2.5/weather";

        public string CountryCode(JObject data) => data["sys"]["country"].ToString();

        public string CurrentWeather(JObject data) => data["main"]["temp"].ToString();

        public JObject Request(string cityName)
        {
            string request = $"{weatherApiUrl}?q={cityName}&units=metric&appid={weatherApiKey}";
            string response = webClient.DownloadString(request);
            JObject data = JObject.Parse(response);

            return data;
        }
    }
}
