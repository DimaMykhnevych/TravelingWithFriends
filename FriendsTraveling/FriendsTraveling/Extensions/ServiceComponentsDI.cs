using FriendsTraveling.BusinessLayer.Factories.AuthTokenFactory;
using FriendsTraveling.BusinessLayer.Services.LocationService;
using FriendsTraveling.BusinessLayer.Services.RouteService;
using FriendsTraveling.BusinessLayer.Services.TransportService;
using FriendsTraveling.BusinessLayer.Services.UserAuthorizationService;
using FriendsTraveling.BusinessLayer.Services.UserService;
using FriendsTraveling.DataLayer.Repositories.LocationRepository;
using FriendsTraveling.DataLayer.Repositories.RouteRepository;
using FriendsTraveling.DataLayer.Repositories.TransportRepository;
using Microsoft.Extensions.DependencyInjection;

namespace FriendsTraveling.Extensions
{
    public static class ServiceComponentsDI
    {
        public static void AddBusinessComponents(this IServiceCollection services)
        {
            //factories
            services.AddTransient<IAuthTokenFactory, AuthTokenFactory>();

            //serivces
            services.AddTransient<BaseAuthorizationService, AppUserAuthorizationService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ITransportService, TransportService>();
            services.AddTransient<ILocationService, LocationService>();
            services.AddTransient<IRouteService, RouteService>();

            //repositories
            services.AddTransient<ITransportRepository, TransportRepository>();
            services.AddTransient<ILocationRepository, LocationRepository>();
            services.AddTransient<IRouteRepository, RouteRepository>();
        }
    }
}
