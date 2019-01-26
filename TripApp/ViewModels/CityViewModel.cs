using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json.Linq;
using System;
using TripApp.Services;
using TripApp.Models;
using TripApp.Messages;
using GalaSoft.MvvmLight.Messaging;

namespace TripApp.ViewModels
{
    class CityViewModel : ViewModelBase
    {
        private City city = new City();
        public City City { get => city; set => Set(ref city, value); }

        private string cityName;
        public string CityName { get => cityName; set => Set(ref cityName, value); }

        private string cityNameForView;
        public string CityNameForView { get => cityNameForView; set => Set(ref cityNameForView, value); }

        private string countryCode;
        public string CountryCode { get => countryCode; set => Set(ref countryCode, value); }

        private string currentWeather;
        public string CurrentWeather { get => currentWeather; set => Set(ref currentWeather, value); }

        private string countryName;
        public string CountryName { get => countryName; set => Set(ref countryName, value); }

        private string currency;
        public string Currency { get => currency; set => Set(ref currency, value); }

        private string language;
        public string Language { get => language; set => Set(ref language, value); }

        readonly ICountryRequest CountryRequest = new CountryRequest();
        readonly IWeatherRequest WeatherRequest = new WeatherRequest();
        private readonly INavigationService navigationService;

        public CityViewModel(INavigationService navigationService) => this.navigationService = navigationService;

        private RelayCommand searchCityInfoCommand;
        public RelayCommand SearchCityInfoCommand
        {
            get => searchCityInfoCommand ?? (searchCityInfoCommand = new RelayCommand(
                () =>
                {
                    try
                    {                       
                        City.CityName = CityName;

                        JObject weatherRequest = WeatherRequest.Request(CityName);
                        cityNameForView = $"City name\n{CityName}";
                        CurrentWeather = $"Current weather\n{WeatherRequest.CurrentWeather(weatherRequest)}°C";

                        JObject countryRequest = CountryRequest.Request(WeatherRequest.CountryCode(weatherRequest));
                        CountryName = $"Country name\n{CountryRequest.CountryName(countryRequest)}";
                        Language = $"Language\n{CountryRequest.Language(countryRequest)}";
                        Currency = $"Currency\n{CountryRequest.Currency(countryRequest)}";
                    }
                    catch (Exception ex)
                    {
                        System.Windows.MessageBox.Show(ex.Message);
                    }

                }
            ));
        }

        private RelayCommand showCityInMapCommand;
        public RelayCommand ShowCityInMapCommand
        {
            get => showCityInMapCommand ?? (showCityInMapCommand = new RelayCommand(
                () =>
                {
                    navigationService.Navigate<RouteMapViewModel>();
                    Messenger.Default.Send(new CityMessage { Item = City });
                }
            ));
        }
    }
}
