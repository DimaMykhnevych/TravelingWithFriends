using FriendsTraveling.BusinessLayer.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendsTraveling.BusinessLayer.Services.Abstract
{
    public interface IJourneyRequestService
    {
        Task<AddJourneyRequestDto> AddJourneyRequest(AddJourneyRequestDto addJourneyRequestDto);
        Task<JourneyRequestDto> GetRequestByJourneyId(int journeyId);
        Task<IEnumerable<ReviewJourneyRequestDto>> GetUserRequestsWithJourneys(int requestedUserId);
        Task DeleteRequestsByJourneyId(int journeyId);
    }
}
