using FriendsTraveling.BusinessLayer.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendsTraveling.BusinessLayer.Services.Abstract
{
    public interface IJourneyService
    {
        Task<IEnumerable<JourneyDto>> SearchJourney(SearchJourneyDto parameters);
        Task<JourneyDto> GetJourneyById(int id);
        Task<JourneyDto> AddJourney(JourneyDto journeyDTO);
        Task<JourneyDto> UpdateJourney(int id, JourneyDto journeyDTO, string username);
        Task<bool> DeleteJourney(int id);
    }
}
