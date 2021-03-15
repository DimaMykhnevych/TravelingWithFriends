using FriendsTraveling.BusinessLayer.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendsTraveling.BusinessLayer.Services.Abstract
{
    public interface IChatService
    {
        Task<IEnumerable<ChatDto>> GetUserChats(int userId);
    }
}
