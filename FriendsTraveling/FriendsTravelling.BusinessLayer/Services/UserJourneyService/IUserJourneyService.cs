using FriendsTraveling.BusinessLayer.DTOs.UserJourneyDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendsTraveling.BusinessLayer.Services.UserJourneyService
{
    public interface IUserJourneyService
    {
        Task<UserJourneyDTO> GetUserJourneyById(int id);
        Task<IEnumerable<UserJourneyDTO>> GetUserJourneys();
        Task<UserJourneyDTO> AddUserJourney(UserJourneyDTO userJourneyDTO);
        Task<UserJourneyDTO> UpdateUserJourney(int id, UserJourneyDTO userJourneyDTO);
        Task<bool> DeleteUserJourney(int id);
    }
}
