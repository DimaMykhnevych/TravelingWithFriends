using AutoMapper;
using FriendsTraveling.BusinessLayer.DTOs;
using FriendsTraveling.BusinessLayer.Services.Abstract;
using FriendsTraveling.DataLayer.Models;
using FriendsTraveling.DataLayer.Repositories.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendsTraveling.BusinessLayer.Services.Concrete
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

        public async Task<RouteDto> AddRoute(RouteDto routeDTO)
        {
            Route route = _mapper.Map<Route>(routeDTO);
            await _routeRepository.Insert(route);
            await _routeRepository.Save();

            return _mapper.Map<RouteDto>(route);
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

        public async Task<RouteDto> GetRouteById(int id)
        {
            Route route = await _routeRepository.Get(id);
            return _mapper.Map<RouteDto>(route);
        }

        public async Task<IEnumerable<RouteDto>> GetRoutes()
        {
            IEnumerable<Route> routes = await _routeRepository.GetAll();
            return _mapper.Map<IEnumerable<RouteDto>>(routes);
        }

        public async Task<RouteDto> UpdateRoute(int id, RouteDto routeDTO)
        {
            Route route = _mapper.Map<Route>(routeDTO);
            route.Id = id;
            await _routeRepository.Update(route);
            return _mapper.Map<RouteDto>(route);
        }
    }
}
