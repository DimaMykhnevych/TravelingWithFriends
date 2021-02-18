using FriendsTraveling.DataLayer.DbContext;
using FriendsTraveling.DataLayer.Models;
using FriendsTraveling.DataLayer.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FriendsTraveling.DataLayer.Repositories.Concrete
{
    public class JourneyRepository : Repository<Journey>, IJourneyRepository
    {
        public JourneyRepository(TravelingDbContext context) : base(context) { }

        public async Task<IEnumerable<Journey>> GetAllJourneysExceptCurrentUser(int userId)
        {
            return await
                 GetFullJourneyInfo()
                .Where(j => j.OrganizerId != userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Journey>> GetCurrentUserJourneys(int userId)
        {
            return await 
                 GetFullJourneyInfo()
                .Where(j => j.OrganizerId == userId)
                .ToListAsync();
        }

        public async Task<Journey> GetJourneyWithRoutesById(int id)
        {
            return await
                 GetFullJourneyInfo()
                .SingleOrDefaultAsync(j => j.Id == id);
        }

        private IQueryable<Journey> GetFullJourneyInfo()
        {
            return  Context.Journeys
              .Include(j => j.Route)
              .Include(j => j.UserJourneys)
              .ThenInclude(uj => uj.AppUser)
              .ThenInclude(u => u.ProfileImage)
              .Include(j => j.Route.Transport)
              .Include(j => j.Route.RouteLocations)
              .ThenInclude(j => j.Location);
        }
    }
}
