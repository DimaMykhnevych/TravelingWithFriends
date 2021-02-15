using FriendsTraveling.BusinessLayer.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendsTraveling.BusinessLayer.Services.Abstract
{
    public interface IJourneyService
    {
        Task<JourneyDto> GetJourneyById(int id);
        Task<IEnumerable<JourneyDto>> GetJourneys();
        Task<IEnumerable<JourneyDto>> GetCurrentUserJourneys(string username);
        Task<JourneyDto> AddJourney(JourneyDto journeyDTO);
        Task<JourneyDto> UpdateJourney(int id, JourneyDto journeyDTO, string username);
        Task<bool> DeleteJourney(int id);
    }
}
