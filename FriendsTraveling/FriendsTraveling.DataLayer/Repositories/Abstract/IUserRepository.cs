using FriendsTraveling.DataLayer.Models;
using FriendsTraveling.DataLayer.Models.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendsTraveling.DataLayer.Repositories.Abstract
{
    public interface IUserRepository : IRepository<AppUser>
    {
        Task<AppUser> GetUserWithImage(int id);
        Task<IEnumerable<JourneyRequest>> GetUserRequestsById(int id);
        Task<AppUser> GetAllUserInfoById(int id);
    }
}
