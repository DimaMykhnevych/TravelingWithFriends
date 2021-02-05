using FriendsTraveling.DataLayer.DbContext;
using FriendsTraveling.DataLayer.Models;
using FriendsTraveling.DataLayer.Repositories.Abstract;

namespace FriendsTraveling.DataLayer.Repositories.Concrete
{
    public class LocationRepository : Repository<Location>, ILocationRepository
    {
        public LocationRepository(TravelingDbContext context) : base(context) { }
    }
}
