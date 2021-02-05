using FriendsTraveling.BusinessLayer.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendsTraveling.BusinessLayer.Services.Abstract
{
    public interface IUserJourneyService
    {
        Task<UserJourneyDto> GetUserJourneyById(int id);
        Task<IEnumerable<UserJourneyDto>> GetUserJourneys();
        Task<UserJourneyDto> AddUserJourney(UserJourneyDto userJourneyDTO);
        Task<UserJourneyDto> UpdateUserJourney(int id, UserJourneyDto userJourneyDTO);
        Task<bool> DeleteUserJourney(int id);
    }
}
