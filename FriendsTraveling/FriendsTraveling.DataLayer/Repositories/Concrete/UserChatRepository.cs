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
    public class UserChatRepository: Repository<UserChat>, IUserChatRepository
    {
        public UserChatRepository(TravelingDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<AppUser>> GetChatParticipants(int chatId)
        {
            return await Context.UserChats
                        .Include(uc => uc.AppUser)
                        .ThenInclude(uc => uc.ProfileImage)
                        .Where(uc => uc.ChatId == chatId)
                        .Select(uc => uc.AppUser)
                        .ToListAsync();
        }

        public async Task<UserChat> GetUserChatByChatIdAndUserId(int chatId, int userId)
        {
            return await Context.UserChats
                .FirstOrDefaultAsync(uc => uc.ChatId == chatId && uc.AppUserId == userId);
        }
    }
}
