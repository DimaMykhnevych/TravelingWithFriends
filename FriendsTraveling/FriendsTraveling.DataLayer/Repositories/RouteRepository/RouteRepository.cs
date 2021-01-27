using FriendsTraveling.DataLayer.DbContext;
using FriendsTraveling.DataLayer.Models;

namespace FriendsTraveling.DataLayer.Repositories.RouteRepository
{
    public class RouteRepository : Repository<Route>, IRouteRepository
    {
        public RouteRepository(TravelingDbContext context) : base(context) { }

    }
}
