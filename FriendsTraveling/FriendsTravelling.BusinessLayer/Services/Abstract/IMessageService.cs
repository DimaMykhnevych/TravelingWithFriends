using FriendsTraveling.BusinessLayer.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendsTraveling.BusinessLayer.Services.Abstract
{
    public interface IMessageService
    {
        Task<IEnumerable<MessageDto>> GetChatMessages(int chatId);
        Task<MessageDto> PostMessage(MessageDto messageDto);
    }
}
