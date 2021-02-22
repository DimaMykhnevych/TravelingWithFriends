using AutoMapper;
using FriendsTraveling.BusinessLayer.DTOs;
using FriendsTraveling.BusinessLayer.Services.Abstract;
using FriendsTraveling.DataLayer.Builders.Abstract;
using FriendsTraveling.DataLayer.Models;
using FriendsTraveling.DataLayer.Models.User;
using FriendsTraveling.DataLayer.Repositories.Abstract;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FriendsTraveling.BusinessLayer.Services.Concrete
{
    public class JourneyService : IJourneyService
    {
        private readonly IJourneyRepository _journeyRepository;
        private readonly ITransportRepository _transportRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;
        private readonly IJourneySearchQueryBuilder _query;
        private readonly UserManager<AppUser> _userManager;

        public JourneyService(IJourneyRepository journeyRepository,
            IMapper mapper,
            UserManager<AppUser> userManager,
            ITransportRepository transportRepository,
            ILocationRepository locationRepository,
            IJourneySearchQueryBuilder query)
        {
            _journeyRepository = journeyRepository;
            _mapper = mapper;
            _userManager = userManager;
            _transportRepository = transportRepository;
            _locationRepository = locationRepository;
            _query = query;

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
            foreach (var location in journeyToDelete.Route.RouteLocations)
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
            Journey journey = await _journeyRepository.GetJourneyWithRoutesById(id);
            return _mapper.Map<JourneyDto>(journey);
        }

        public async Task<JourneyDto> UpdateJourney(int id, JourneyDto journeyDTO, string currentUserName)
        {
            Journey journey = _mapper.Map<Journey>(journeyDTO);
            await _journeyRepository.UpdateJourney(journey);
            await DeleteRemovedJourneys(journeyDTO);
            return _mapper.Map<JourneyDto>(journey);
        }

        public IEnumerable<JourneyDto> SearchJourney(SearchJourneyDto parameters)
        {
            List<Journey> journeys =
                _query.SetBaseJourneyInfo()
                .GetJourneysDependsOnCurrentUser(parameters.UserId, parameters.IsForCurrentUser)
                .SetJourneyPrice(parameters.StartPrice, parameters.EndPrice)
                .SetJourneyRequiredAge(parameters.MinAge, parameters.MaxAge)
                .Build()
                .ToList();
            return _mapper.Map<IEnumerable<JourneyDto>>(journeys);

        }

        private async Task DeleteRemovedJourneys(JourneyDto journeyDTO)
        {
            Journey beforeUpdateJourney = await _journeyRepository.GetJourneyWithRoutesById(journeyDTO.Id);
            int locationsCount = beforeUpdateJourney.Route.RouteLocations.Count;
            int locationDifference = locationsCount - journeyDTO.Route.RouteLocations.Count;
            if (locationDifference > 0)
            {
                foreach (var rl in beforeUpdateJourney.Route.RouteLocations)
                {
                    if (!journeyDTO.Route.RouteLocations.Exists(r => r.LocationId == rl.LocationId))
                    {
                        await _locationRepository.Delete(rl.Location);
                    }
                }
                await _locationRepository.Save();
            }
        }
    }
}
