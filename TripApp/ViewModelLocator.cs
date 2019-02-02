using Autofac;
using Autofac.Configuration;
using GalaSoft.MvvmLight;
using Microsoft.Extensions.Configuration;
using TripApp.Services;
using TripApp.ViewModels;

namespace TripApp
{
    class ViewModelLocator
    {
        private readonly AddEditTripViewModel addTripViewModel;
        private readonly AddTicketViewModel addTicketViewModel;
        private readonly CityViewModel cityViewModel;
        private readonly MainWindowViewModel mainWindowViewModel;
        private readonly MenuViewModel menuViewModel;
        private readonly RouteMapViewModel routeMapViewModel;
        private readonly ShowTicketViewModel showTicketViewModel;
        private readonly TicketListViewModel ticketsViewModel;
        private readonly TripListViewModel tripListViewModel;

        private INavigationService navigationService;
        public static IContainer Container;

        public ViewModelLocator()
        {
            ConfigurationBuilder config = new ConfigurationBuilder();
            config.AddJsonFile("autofac.json");
            ConfigurationModule module = new ConfigurationModule(config.Build());
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterModule(module);
            Container = builder.Build();

            navigationService = Container.Resolve<INavigationService>();

            addTripViewModel = Container.Resolve<AddEditTripViewModel>();
            addTicketViewModel = Container.Resolve<AddTicketViewModel>();
            cityViewModel = Container.Resolve<CityViewModel>();
            mainWindowViewModel = Container.Resolve<MainWindowViewModel>();
            menuViewModel = Container.Resolve<MenuViewModel>();
            routeMapViewModel = Container.Resolve<RouteMapViewModel>();
            showTicketViewModel = Container.Resolve<ShowTicketViewModel>();
            tripListViewModel = Container.Resolve<TripListViewModel>();
            ticketsViewModel = Container.Resolve<TicketListViewModel>();

            navigationService.Register<AddEditTripViewModel>(addTripViewModel);
            navigationService.Register<AddTicketViewModel>(addTicketViewModel);
            navigationService.Register<CityViewModel>(cityViewModel);
            navigationService.Register<MenuViewModel>(menuViewModel);
            navigationService.Register<RouteMapViewModel>(routeMapViewModel);
            navigationService.Register<ShowTicketViewModel>(showTicketViewModel);
            navigationService.Register<TicketListViewModel>(ticketsViewModel);
            navigationService.Register<TripListViewModel>(tripListViewModel);

            navigationService.Navigate<TripListViewModel>();
        }

        public ViewModelBase GetMainWindowViewModel() => mainWindowViewModel;
    }
}
