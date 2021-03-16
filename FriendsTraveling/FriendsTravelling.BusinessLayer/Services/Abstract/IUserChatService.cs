using FriendsTraveling.DataLayer.Models.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendsTraveling.BusinessLayer.Services.Abstract
{
    public interface IUserChatService
    {
        Task<IEnumerable<AppUser>> GetChatParticipants(int chatId);
    }
}
