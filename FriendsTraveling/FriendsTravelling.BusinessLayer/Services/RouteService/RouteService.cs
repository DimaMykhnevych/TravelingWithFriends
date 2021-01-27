using AutoMapper;
using FriendsTraveling.BusinessLayer.DTOs.RouteDTOs;
using FriendsTraveling.DataLayer.Models;
using FriendsTraveling.DataLayer.Repositories.RouteRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendsTraveling.BusinessLayer.Services.RouteService
{
    public class RouteService : IRouteService
    {
        private readonly IRouteRepository _routeRepository;
        private readonly IMapper _mapper;

        public RouteService(IRouteRepository routeRepository, IMapper mapper)
        {
            _routeRepository = routeRepository;
            _mapper = mapper;
        }

        public async Task<RouteDTO> AddRoute(RouteDTO routeDTO)
        {
            Route route = _mapper.Map<Route>(routeDTO);
            await _routeRepository.Insert(route);
            await _routeRepository.Save();

            return _mapper.Map<RouteDTO>(route);
        }

        public async Task<bool> DeleteRoute(int id)
        {
            Route routeToDelete = await _routeRepository.Get(id);
            if (routeToDelete == null)
                return false;
            await _routeRepository.Delete(routeToDelete);
            await _routeRepository.Save();
            return true;
        }

        public async Task<RouteDTO> GetRouteById(int id)
        {
            Route route = await _routeRepository.Get(id);
            return _mapper.Map<RouteDTO>(route);
        }

        public async Task<IEnumerable<RouteDTO>> GetRoutes()
        {
            IEnumerable<Route> routes = await _routeRepository.GetAll();
            return _mapper.Map<IEnumerable<RouteDTO>>(routes);
        }

        public async Task<RouteDTO> UpdateRoute(int id, RouteDTO routeDTO)
        {
            Route route = _mapper.Map<Route>(routeDTO);
            route.Id = id;
            await _routeRepository.Update(route);
            return _mapper.Map<RouteDTO>(route);
        }
    }
}
