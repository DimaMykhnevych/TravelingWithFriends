using AutoMapper;
using FriendsTraveling.BusinessLayer.DTOs;
using FriendsTraveling.BusinessLayer.Services.Abstract;
using FriendsTraveling.DataLayer.Models;
using FriendsTraveling.DataLayer.Models.User;
using FriendsTraveling.DataLayer.Repositories.Abstract;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendsTraveling.BusinessLayer.Services.Concrete
{
    public class JourneyService : IJourneyService
    {
        private readonly IJourneyRepository _journeyRepository;
        private readonly ITransportRepository _transportRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public JourneyService(IJourneyRepository journeyRepository,
            IMapper mapper,
            UserManager<AppUser> userManager, 
            ITransportRepository transportRepository,
            ILocationRepository locationRepository)
        {
            _journeyRepository = journeyRepository;
            _mapper = mapper;
            _userManager = userManager;
            _transportRepository = transportRepository;
            _locationRepository = locationRepository;

        }

        public async Task<JourneyDto> AddJourney(JourneyDto journeyDTO)
        {
            Journey journey = _mapper.Map<Journey>(journeyDTO);
            var j = await _journeyRepository.Insert(journey);
            await _journeyRepository.Save();

            return _mapper.Map<JourneyDto>(journey);
        }

        public async Task<bool> DeleteJourney(int id)
        {
            Journey journeyToDelete = await _journeyRepository.GetJourneyWithRoutesById(id);
            if (journeyToDelete == null)
                return false;
            await _journeyRepository.Delete(journeyToDelete);
            await _transportRepository.Delete(journeyToDelete.Route.Transport);
            foreach(var location in journeyToDelete.Route.RouteLocations)
            {
                await _locationRepository.Delete(location.Location);
            }
            await _journeyRepository.Save();
            await _locationRepository.Save();
            await _transportRepository.Save();
            return true;
        }

        public async Task<JourneyDto> GetJourneyById(int id)
        {
            Journey journey = await _journeyRepository.Get(id);
            return _mapper.Map<JourneyDto>(journey);
        }

        public async Task<IEnumerable<JourneyDto>> GetCurrentUserJourneys(string username)
        {
            AppUser currentUser = await _userManager.FindByNameAsync(username);
            IEnumerable<Journey> journeys = await _journeyRepository.GetCurrentUserJourneys(currentUser.Id);
            return _mapper.Map<IEnumerable<JourneyDto>>(journeys);
        }

        public async Task<IEnumerable<JourneyDto>> GetJourneys()
        {
            IEnumerable<Journey> journeys = await _journeyRepository.GetAll();
            return _mapper.Map<IEnumerable<JourneyDto>>(journeys);
        }

        public async Task<JourneyDto> UpdateJourney(int id, JourneyDto journeyDTO)
        {
            Journey journey = _mapper.Map<Journey>(journeyDTO);
            journey.Id = id;
            await _journeyRepository.Update(journey);
            return _mapper.Map<JourneyDto>(journey);
        }
    }
}
