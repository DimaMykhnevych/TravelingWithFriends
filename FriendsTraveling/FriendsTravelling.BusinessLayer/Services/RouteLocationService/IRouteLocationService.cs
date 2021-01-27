using FriendsTraveling.BusinessLayer.DTOs.RouteLocationDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendsTraveling.BusinessLayer.Services.RouteLocationService
{
    public interface IRouteLocationService
    {
        Task<RouteLocationDTO> GetRouteLocationById(int id);
        Task<IEnumerable<RouteLocationDTO>> GetRouteLocations();
        Task<RouteLocationDTO> AddRouteLocation(RouteLocationDTO routeLocationDTO);
        Task<RouteLocationDTO> UpdateRouteLocation(int id, RouteLocationDTO routeLocationDTO);
        Task<bool> DeleteRouteLocation(int id);
    }
}
