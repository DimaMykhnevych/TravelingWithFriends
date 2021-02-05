using FriendsTraveling.BusinessLayer.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendsTraveling.BusinessLayer.Services.Abstract
{
    public interface IRouteLocationService
    {
        Task<RouteLocationDto> GetRouteLocationById(int id);
        Task<IEnumerable<RouteLocationDto>> GetRouteLocations();
        Task<RouteLocationDto> AddRouteLocation(RouteLocationDto routeLocationDTO);
        Task<RouteLocationDto> UpdateRouteLocation(int id, RouteLocationDto routeLocationDTO);
        Task<bool> DeleteRouteLocation(int id);
    }
}
