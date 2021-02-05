using FriendsTraveling.BusinessLayer.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendsTraveling.BusinessLayer.Services.Abstract
{
    public interface ILocationService
    {
        Task<LocationDto> GetLocationById(int id);
        Task<IEnumerable<LocationDto>> GetLocations();
        Task<LocationDto> AddLocation(LocationDto locationDTO);
        Task<LocationDto> UpdateLocation(int id, LocationDto locationDTO);
        Task<bool> DeleteLocation(int id);
    }
}
