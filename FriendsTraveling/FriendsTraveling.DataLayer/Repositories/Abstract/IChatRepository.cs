using FriendsTraveling.DataLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendsTraveling.DataLayer.Repositories.Abstract
{
    public interface IChatRepository: IRepository<Chat>
    {
        public Task<IEnumerable<Chat>> GetUserChats(int userId);
        public Task<Chat> GetChatByJourneyId(int journeyId);
    }
}
