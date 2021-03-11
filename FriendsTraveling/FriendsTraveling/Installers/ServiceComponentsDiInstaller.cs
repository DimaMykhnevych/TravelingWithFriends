using FriendsTraveling.BusinessLayer.Factories.AuthTokenFactory;
using FriendsTraveling.BusinessLayer.Services.Abstract;
using FriendsTraveling.BusinessLayer.Services.Concrete;
using FriendsTraveling.DataLayer.Builders.Abstract;
using FriendsTraveling.DataLayer.Builders.Concrete;
using FriendsTraveling.DataLayer.Repositories.Abstract;
using FriendsTraveling.DataLayer.Repositories.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FriendsTraveling.Web.Installers
{
    public class ServiceComponentsDiInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            //factories
            services.AddTransient<IAuthTokenFactory, AuthTokenFactory>();

            //serivces
            services.AddTransient<BaseAuthorizationService, AppUserAuthorizationService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ITransportService, TransportService>();
            services.AddTransient<ILocationService, LocationService>();
            services.AddTransient<IRouteService, RouteService>();
            services.AddTransient<IRouteLocationService, RouteLocationService>();
            services.AddTransient<IJourneyService, JourneyService>();
            services.AddTransient<IUserJourneyService, UserJourneyService>();
            services.AddTransient<IImageService, ImageService>();
            services.AddTransient<IAddJourneyService, AddJourneyService>();
            services.AddTransient<IJourneyRequestService, JourneyRequestService>();
            services.AddTransient<IEmailService, EmailService>();

            //builders
            services.AddTransient<IJourneySearchQueryBuilder, JourneySearchQueryBuilder>();


            //repositories
            services.AddTransient<ITransportRepository, TransportRepository>();
            services.AddTransient<ILocationRepository, LocationRepository>();
            services.AddTransient<IRouteRepository, RouteRepository>();
            services.AddTransient<IRouteLocationRepository, RouteLocationRepository>();
            services.AddTransient<IJourneyRepository, JourneyRepository>();
            services.AddTransient<IUserJourneyRepository, UserJourneyRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IImageRepository, ImageRepository>();
            services.AddTransient<IJourneyRequestRepository, JourneyRequestRepository>();
        }
    }
}
