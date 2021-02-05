using FriendsTraveling.DataLayer.DbContext;
using FriendsTraveling.DataLayer.Models;
using FriendsTraveling.DataLayer.Repositories.Abstract;

namespace FriendsTraveling.DataLayer.Repositories.Concrete
{
    public class RouteRepository : Repository<Route>, IRouteRepository
    {
        public RouteRepository(TravelingDbContext context) : base(context) { }

    }
}
