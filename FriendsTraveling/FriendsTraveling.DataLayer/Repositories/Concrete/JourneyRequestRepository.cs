using FriendsTraveling.DataLayer.DbContext;
using FriendsTraveling.DataLayer.Models;
using FriendsTraveling.DataLayer.Repositories.Abstract;
namespace FriendsTraveling.DataLayer.Repositories.Concrete
{
    public class JourneyRequestRepository: Repository<JourneyRequest>, IJourneyRequestRepository
    {
        public JourneyRequestRepository(TravelingDbContext context) : base(context) { }

    }
}
