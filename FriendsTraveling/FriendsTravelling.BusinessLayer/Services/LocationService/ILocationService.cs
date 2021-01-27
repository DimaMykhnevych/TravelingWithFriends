using FriendsTraveling.BusinessLayer.DTOs.LocationDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendsTraveling.BusinessLayer.Services.LocationService
{
    public interface ILocationService
    {
        Task<LocationDTO> GetLocationById(int id);
        Task<IEnumerable<LocationDTO>> GetLocations();
        Task<LocationDTO> AddLocation(LocationDTO locationDTO);
        Task<LocationDTO> UpdateLocation(int id, LocationDTO locationDTO);
        Task<bool> DeleteLocation(int id);
    }
}
