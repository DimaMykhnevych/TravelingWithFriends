using FriendsTraveling.DataLayer.DbContext;
using FriendsTraveling.DataLayer.Models;
using FriendsTraveling.DataLayer.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FriendsTraveling.DataLayer.Repositories.Concrete
{
    public class ChatRepository : Repository<Chat>, IChatRepository
    {
        public ChatRepository(TravelingDbContext context) : base(context)
        {

        }

        public async Task<Chat> GetChatByJourneyId(int journeyId)
        {
            return await Context.Chats.FirstOrDefaultAsync(c => c.JourneyChatId == journeyId);
        }

        public async Task<IEnumerable<Chat>> GetUserChats(int userId)
        {
            return await Context.UserChats
                .Where(c => c.AppUserId == userId)
                .Include(c => c.Chat.Journey)
                .Select(c => c.Chat)
                .ToListAsync();
        }
    }
}
