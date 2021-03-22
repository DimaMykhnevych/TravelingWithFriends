using FriendsTraveling.DataLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendsTraveling.DataLayer.Repositories.Abstract
{
    public interface IChatRepository: IRepository<Chat>
    {
         Task<IEnumerable<Chat>> GetUserChats(int userId);
         Task<Chat> GetChatByJourneyId(int journeyId);
        
    }
}
