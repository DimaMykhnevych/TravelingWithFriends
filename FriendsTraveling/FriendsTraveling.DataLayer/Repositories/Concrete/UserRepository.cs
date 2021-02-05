using FriendsTraveling.DataLayer.DbContext;
using FriendsTraveling.DataLayer.Models.User;
using FriendsTraveling.DataLayer.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FriendsTraveling.DataLayer.Repositories.Concrete
{
    public class UserRepository: Repository<AppUser>, IUserRepository
    {
        public UserRepository(TravelingDbContext context) : base(context) { }

        public async Task<AppUser> GetUserWithImage(int id)
        {
            return await Context.AppUsers.Include(u => u.ProfileImage).
                FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}
