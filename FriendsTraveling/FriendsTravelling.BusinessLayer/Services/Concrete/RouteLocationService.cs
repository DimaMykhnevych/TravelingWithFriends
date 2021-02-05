using AutoMapper;
using FriendsTraveling.BusinessLayer.DTOs;
using FriendsTraveling.BusinessLayer.Services.Abstract;
using FriendsTraveling.DataLayer.Models;
using FriendsTraveling.DataLayer.Repositories.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendsTraveling.BusinessLayer.Services.Concrete
{
    public class RouteLocationService : IRouteLocationService
    {
        private readonly IRouteLocationRepository _routeLocationRepository;
        private readonly IMapper _mapper;

        public RouteLocationService(IRouteLocationRepository routeLocationRepository, IMapper mapper)
        {
            _routeLocationRepository = routeLocationRepository;
            _mapper = mapper;
        }

        public async Task<RouteLocationDto> AddRouteLocation(RouteLocationDto routeLocationDTO)
        {
            RouteLocation routeLocation = _mapper.Map<RouteLocation>(routeLocationDTO);
            await _routeLocationRepository.Insert(routeLocation);
            await _routeLocationRepository.Save();

            return _mapper.Map<RouteLocationDto>(routeLocation);
        }

        public async Task<bool> DeleteRouteLocation(int id)
        {
            RouteLocation routeLocationToDelete = await _routeLocationRepository.Get(id);
            if (routeLocationToDelete == null)
                return false;
            await _routeLocationRepository.Delete(routeLocationToDelete);
            await _routeLocationRepository.Save();
            return true;
        }

        public async Task<RouteLocationDto> GetRouteLocationById(int id)
        {
            RouteLocation routeLocation = await _routeLocationRepository.Get(id);
            return _mapper.Map<RouteLocationDto>(routeLocation);
        }

        public async Task<IEnumerable<RouteLocationDto>> GetRouteLocations()
        {
            IEnumerable<RouteLocation> routeLocations = await _routeLocationRepository.GetAll();
            return _mapper.Map<IEnumerable<RouteLocationDto>>(routeLocations);
        }

        public async Task<RouteLocationDto> UpdateRouteLocation(int id, RouteLocationDto routeLocationDTO)
        {
            RouteLocation routeLocation = _mapper.Map<RouteLocation>(routeLocationDTO);
            routeLocation.Id = id;
            await _routeLocationRepository.Update(routeLocation);
            return _mapper.Map<RouteLocationDto>(routeLocation);
        }
    }
}
