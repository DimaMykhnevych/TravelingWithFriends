using FriendsTraveling.DataLayer.DbContext;
using FriendsTraveling.DataLayer.Models;
using FriendsTraveling.DataLayer.Models.User;
using FriendsTraveling.DataLayer.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FriendsTraveling.DataLayer.Repositories.Concrete
{
    public class UserRepository: Repository<AppUser>, IUserRepository
    {
        public UserRepository(TravelingDbContext context) : base(context) { }

        public Task<AppUser> GetAllUserInfoById(int id)
        {
            return Context.AppUsers
                .Include(u => u.ProfileImage)
                .Include(u => u.UserJourneys)
                .ThenInclude(u => u.Journey)
                .ThenInclude(j => j.Route)
                .ThenInclude(j => j.RouteLocations)
                .ThenInclude(r => r.Location)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<AppUser> GetUserWithImage(int id)
        {
            return await Context.AppUsers.Include(u => u.ProfileImage).
                FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<JourneyRequest>> GetUserRequestsById(int id)
        {
            return await Context.JourneyRequests
                .Where(jr => jr.RequestUserId == id).ToListAsync();
        }
    }
}
