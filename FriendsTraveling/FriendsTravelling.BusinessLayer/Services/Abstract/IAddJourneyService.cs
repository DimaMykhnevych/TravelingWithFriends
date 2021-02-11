using FriendsTraveling.BusinessLayer.DTOs;
using System.Threading.Tasks;

namespace FriendsTraveling.BusinessLayer.Services.Abstract
{
    public interface IAddJourneyService
    {
        Task<JourneyDto> AddJourney(AddJourneyDto journey, string currentUserName);
    }
}
