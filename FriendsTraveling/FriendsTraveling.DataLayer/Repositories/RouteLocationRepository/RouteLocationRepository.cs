using FriendsTraveling.DataLayer.DbContext;
using FriendsTraveling.DataLayer.Models;

namespace FriendsTraveling.DataLayer.Repositories.RouteLocationRepository
{
    public class RouteLocationRepository :  Repository<RouteLocation>, IRouteLocationRepository
    {
        public RouteLocationRepository(TravelingDbContext context) : base(context) { }
    }
}
