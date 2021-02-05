using FriendsTraveling.BusinessLayer.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendsTraveling.BusinessLayer.Services.Abstract
{
    public interface IRouteService
    {
        Task<RouteDto> GetRouteById(int id);
        Task<IEnumerable<RouteDto>> GetRoutes();
        Task<RouteDto> AddRoute(RouteDto routeDTO);
        Task<RouteDto> UpdateRoute(int id, RouteDto routeDTO);
        Task<bool> DeleteRoute(int id);
    }
}
