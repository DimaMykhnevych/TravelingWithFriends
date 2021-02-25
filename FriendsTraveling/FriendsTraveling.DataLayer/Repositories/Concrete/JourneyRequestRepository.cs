using FriendsTraveling.DataLayer.DbContext;
using FriendsTraveling.DataLayer.Models;
using FriendsTraveling.DataLayer.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<JourneyRequest>> GetUserRequests(int requestedUserId)
        {
            return await Context.JourneyRequests
                .Where(r => r.RequestUserId == requestedUserId)
                .Include(r => r.Organizer)
                .Include(r => r.RequestUser)
                .ToListAsync();
        }
    }
}
