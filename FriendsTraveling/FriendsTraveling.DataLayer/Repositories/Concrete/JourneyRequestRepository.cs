using FriendsTraveling.DataLayer.DbContext;
using FriendsTraveling.DataLayer.Models;
using FriendsTraveling.DataLayer.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FriendsTraveling.DataLayer.Repositories.Concrete
{
    public class JourneyRequestRepository: Repository<JourneyRequest>, IJourneyRequestRepository
    {
        public JourneyRequestRepository(TravelingDbContext context) : base(context) { }

        public async Task<JourneyRequest> GetRequestByJourneyId(int journeyId)
        {
            return await Context.JourneyRequests
                .FirstOrDefaultAsync(jr => jr.RequestedJourneyId == journeyId);
        }
    }
}
