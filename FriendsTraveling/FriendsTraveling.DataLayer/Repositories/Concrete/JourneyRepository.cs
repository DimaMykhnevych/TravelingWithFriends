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

        public async Task<IEnumerable<Journey>> GetCurrentUserJourneys(int userId)
        {
            return await Context.Journeys
                .Include(j => j.Route)
                .Include(j => j.Route.Transport)
                .Include(j => j.Route.RouteLocations)
                .ThenInclude(j => j.Location)
                .Where(j => j.OrganizerId == userId)
                .ToListAsync();
        }

        public async Task<Journey> GetJourneyWithRoutesById(int id)
        {
            return await Context.Journeys
                .Include(j => j.Route)
                .Include(j => j.Route.Transport)
                .Include(j => j.Route.RouteLocations)
                .ThenInclude(j => j.Location)
                .SingleOrDefaultAsync(j => j.Id == id);
        }
    }
}
