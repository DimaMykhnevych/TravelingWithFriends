using FriendsTraveling.DataLayer.DbContext;
using FriendsTraveling.DataLayer.Models;
using FriendsTraveling.DataLayer.Repositories.Abstract;

namespace FriendsTraveling.DataLayer.Repositories.Concrete
{
    public class JourneyRepository : Repository<Journey>, IJourneyRepository
    {
        public JourneyRepository(TravelingDbContext context) : base(context) { }
    }
}
