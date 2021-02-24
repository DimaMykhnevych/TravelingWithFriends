using FriendsTraveling.DataLayer.Models;
using System.Threading.Tasks;

namespace FriendsTraveling.DataLayer.Repositories.Abstract
{
    public interface IJourneyRequestRepository: IRepository<JourneyRequest>
    {
        Task<JourneyRequest> GetRequestByJourneyId(int journeyId);
    }
}
