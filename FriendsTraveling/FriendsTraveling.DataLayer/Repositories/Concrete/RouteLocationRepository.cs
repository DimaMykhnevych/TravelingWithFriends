using FriendsTraveling.DataLayer.DbContext;
using FriendsTraveling.DataLayer.Models;
using FriendsTraveling.DataLayer.Repositories.Abstract;

namespace FriendsTraveling.DataLayer.Repositories.Concrete
{
    public class RouteLocationRepository :  Repository<RouteLocation>, IRouteLocationRepository
    {
        public RouteLocationRepository(TravelingDbContext context) : base(context) { }
    }
}
