using FriendsTraveling.DataLayer.DbContext;
using FriendsTraveling.DataLayer.Models;
using FriendsTraveling.DataLayer.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FriendsTraveling.DataLayer.Repositories.Concrete
{
    public class MessageRepository : Repository<Message>, IMessageRepository
    {
        public MessageRepository(TravelingDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Message>> GetChatMessages(int chatId)
        {
            return await Context.Messages
                .Include(m => m.Sender)
                .ThenInclude(s => s.ProfileImage)
                .Where(m => m.ChatId == chatId)
                .ToListAsync();
        }

        public async Task<Message> GetMessageWithSenderById(int messageId)
        {
            return await Context.Messages
                .Include(m => m.Sender)
                .ThenInclude(s => s.ProfileImage)
                .FirstOrDefaultAsync(m => m.Id == messageId);
        }
    }
}
