using FriendsTraveling.DataLayer.Models.User;
using System.Threading.Tasks;

namespace FriendsTraveling.DataLayer.Repositories.Abstract
{
    public interface IUserRepository : IRepository<AppUser>
    {
        Task<AppUser> GetUserWithImage(int id);
    }
}
