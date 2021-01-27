using FriendsTraveling.BusinessLayer.DTOs.RouteDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendsTraveling.BusinessLayer.Services.RouteService
{
    public interface IRouteService
    {
        Task<RouteDTO> GetRouteById(int id);
        Task<IEnumerable<RouteDTO>> GetRoutes();
        Task<RouteDTO> AddRoute(RouteDTO routeDTO);
        Task<RouteDTO> UpdateRoute(int id, RouteDTO routeDTO);
        Task<bool> DeleteRoute(int id);
    }
}
