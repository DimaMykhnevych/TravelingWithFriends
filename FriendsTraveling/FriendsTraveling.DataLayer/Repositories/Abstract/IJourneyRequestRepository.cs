using FriendsTraveling.DataLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendsTraveling.DataLayer.Repositories.Abstract
{
    public interface IJourneyRequestRepository: IRepository<JourneyRequest>
    {
        Task<JourneyRequest> GetRequestByJourneyId(int journeyId);
        Task<IEnumerable<JourneyRequest>> GetUserRequests(int requestedUserId);
        Task<IEnumerable<JourneyRequest>> GetUserInboxRequests(int userId);
    }
}
