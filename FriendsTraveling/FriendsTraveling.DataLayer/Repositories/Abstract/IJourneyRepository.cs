using FriendsTraveling.DataLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendsTraveling.DataLayer.Repositories.Abstract
{
    public interface IJourneyRepository : IRepository<Journey>
    {
        Task<IEnumerable<Journey>> GetAllJourneysExceptCurrentUser(int userId);
        Task<IEnumerable<Journey>> GetCurrentUserJourneys(int userId);
        Task<Journey> GetJourneyWithRoutesById(int id);
    }
}
