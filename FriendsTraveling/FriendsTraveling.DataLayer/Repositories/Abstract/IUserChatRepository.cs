using FriendsTraveling.DataLayer.Models;
using FriendsTraveling.DataLayer.Models.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendsTraveling.DataLayer.Repositories.Abstract
{
    public interface IUserChatRepository: IRepository<UserChat>
    {
        Task<UserChat> GetUserChatByChatIdAndUserId(int chatId, int userId);
        Task<IEnumerable<AppUser>> GetChatParticipants(int chatId);
    }
}
