using FriendsTraveling.DataLayer.DbContext;
using FriendsTraveling.DataLayer.Models;
using FriendsTraveling.DataLayer.Repositories.Abstract;

namespace FriendsTraveling.DataLayer.Repositories.Concrete
{
    public class UserChatRepository: Repository<UserChat>, IUserChatRepository
    {
        public UserChatRepository(TravelingDbContext context) : base(context)
        {

        }
    }
}
