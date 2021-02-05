using FriendsTraveling.BusinessLayer.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendsTraveling.BusinessLayer.Services.Abstract
{
    public interface IJourneyService
    {
        Task<JourneyDto> GetJourneyById(int id);
        Task<IEnumerable<JourneyDto>> GetJourneys();
        Task<JourneyDto> AddJourney(JourneyDto journeyDTO);
        Task<JourneyDto> UpdateJourney(int id, JourneyDto journeyDTO);
        Task<bool> DeleteJourney(int id);
    }
}
