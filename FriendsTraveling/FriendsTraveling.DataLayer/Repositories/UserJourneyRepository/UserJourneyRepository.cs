using FriendsTraveling.DataLayer.DbContext;
using FriendsTraveling.DataLayer.Models;

namespace FriendsTraveling.DataLayer.Repositories.UserJourneyRepository
{
    public class UserJourneyRepository : Repository<UserJourney>, IUserJourneyRepository
    {
        public UserJourneyRepository(TravelingDbContext context) : base(context) { }
    }
}
