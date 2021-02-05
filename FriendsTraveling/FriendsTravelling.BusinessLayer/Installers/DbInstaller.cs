using FriendsTraveling.DataLayer.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FriendsTraveling.BusinessLayer.Installers
{
    public static class DbInstaller
    {
        public static void InstallDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TravelingDbContext>(opt =>
                     opt.UseSqlServer(configuration.GetConnectionString("Default")));
        }
    }
}
