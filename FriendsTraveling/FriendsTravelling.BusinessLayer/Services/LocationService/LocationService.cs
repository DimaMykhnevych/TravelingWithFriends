using AutoMapper;
using FriendsTraveling.BusinessLayer.DTOs.LocationDTOs;
using FriendsTraveling.DataLayer.Models;
using FriendsTraveling.DataLayer.Repositories.LocationRepository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendsTraveling.BusinessLayer.Services.LocationService
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;

        public LocationService(ILocationRepository locationRepository, IMapper mapper)
        {
            _locationRepository = locationRepository;
            _mapper = mapper;
        }

        public async Task<LocationDTO> AddLocation(LocationDTO locationDTO)
        {
            Location location = _mapper.Map<Location>(locationDTO);
            await _locationRepository.Insert(location);
            await _locationRepository.Save();

            return _mapper.Map<LocationDTO>(location);
        }

        public async Task<bool> DeleteLocation(int id)
        {
            Location locationToDelete = await _locationRepository.Get(id);
            if (locationToDelete == null)
                return false;
            await _locationRepository.Delete(locationToDelete);
            await _locationRepository.Save();
            return true;
        }

        public async Task<LocationDTO> GetLocationById(int id)
        {
            Location location = await _locationRepository.Get(id);
            return _mapper.Map<LocationDTO>(location);
        }

        public async Task<IEnumerable<LocationDTO>> GetLocations()
        {
            IEnumerable<Location> locations = await _locationRepository.GetAll();
            return _mapper.Map<IEnumerable<LocationDTO>>(locations);
        }

        public async Task<LocationDTO> UpdateLocation(int id, LocationDTO locationDTO)
        {
            Location location = _mapper.Map<Location>(locationDTO);
            location.Id = id;
            await _locationRepository.Update(location);
            return _mapper.Map<LocationDTO>(location);
        }
    }
}
