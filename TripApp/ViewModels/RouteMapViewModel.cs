using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using TripApp.Messages;
using TripApp.Services;

namespace TripApp.ViewModels
{
    class RouteMapViewModel : ViewModelBase
    {
        private readonly INavigationService navigationService;
        private readonly IMessageService messageService;
        
        private string webAddress;
        public string WebAddress { get => webAddress; set => Set(ref webAddress, value); }

        public RouteMapViewModel(INavigationService navigationService, IMessageService messageService)
        {
            this.navigationService = navigationService;
            this.messageService = messageService;

            Messenger.Default.Register<CityMessage>(this,
                msg =>
                {
                    WebAddress = $"https://www.google.com/maps/place/{msg.Item.CityName}";
                });
        }
    }
}
