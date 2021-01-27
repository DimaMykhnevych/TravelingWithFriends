using FriendsTraveling.BusinessLayer.DTOs.JourneyDTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendsTraveling.BusinessLayer.Services.JourneyService
{
    public interface IJourneyService
    {
        Task<JourneyDTO> GetJourneyById(int id);
        Task<IEnumerable<JourneyDTO>> GetJourneys();
        Task<JourneyDTO> AddJourney(JourneyDTO journeyDTO);
        Task<JourneyDTO> UpdateJourney(int id, JourneyDTO journeyDTO);
        Task<bool> DeleteJourney(int id);
    }
}
