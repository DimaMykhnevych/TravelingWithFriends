using FriendsTraveling.DataLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendsTraveling.DataLayer.Repositories.Abstract
{
    public interface IMessageRepository : IRepository<Message>
    {
        Task<IEnumerable<Message>> GetChatMessages(int chatId);
        Task<Message> GetMessageWithSenderById(int messageId);
    }
}
