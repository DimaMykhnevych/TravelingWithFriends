using FriendsTraveling.DataLayer.DbContext;
using FriendsTraveling.DataLayer.Models;

namespace FriendsTraveling.DataLayer.Repositories.JourneyRepository
{
    public class JourneyRepository : Repository<Journey>, IJourneyRepository
    {
        public JourneyRepository(TravelingDbContext context) : base(context) { }
    }
}
