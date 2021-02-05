using FriendsTraveling.DataLayer.DbContext;
using FriendsTraveling.DataLayer.Models;
using FriendsTraveling.DataLayer.Repositories.Abstract;

namespace FriendsTraveling.DataLayer.Repositories.Concrete
{
    public class UserJourneyRepository : Repository<UserJourney>, IUserJourneyRepository
    {
        public UserJourneyRepository(TravelingDbContext context) : base(context) { }
    }
}
