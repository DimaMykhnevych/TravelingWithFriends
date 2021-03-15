using AutoMapper;
using FriendsTraveling.BusinessLayer.DTOs;
using FriendsTraveling.BusinessLayer.Services.Abstract;
using FriendsTraveling.DataLayer.Builders.Abstract;
using FriendsTraveling.DataLayer.Models;
using FriendsTraveling.DataLayer.Repositories.Abstract;
using System;
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
        private readonly IJourneyRequestRepository _journeyRequestRepository;

        public JourneyService(IJourneyRepository journeyRepository,
            IMapper mapper,
            ITransportRepository transportRepository,
            ILocationRepository locationRepository,
            IJourneySearchQueryBuilder query,
            IJourneyRequestRepository journeyRequestRepository)
        {
            _journeyRepository = journeyRepository;
            _mapper = mapper;
            _transportRepository = transportRepository;
            _locationRepository = locationRepository;
            _query = query;
            _journeyRequestRepository = journeyRequestRepository;
        }

        public async Task<JourneyDto> AddJourney(JourneyDto journeyDTO)
        {
            Journey journey = _mapper.Map<Journey>(journeyDTO);
            Chat chat= new Chat()
            {
                Name = $"{journeyDTO.Route.RouteLocations[0].Location.Name} journey chat",
                CreationDate = DateTime.Now,
                Id = 0,
                JourneyChatId = journey.Id,
            };
            chat.UserChats = new List<UserChat>();
            chat.UserChats.Add(new UserChat() { Chat = chat, AppUserId = journeyDTO.OrganizerId });
            journey.Chat = chat;
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
            await DeleteRequestsByJourneyId(id);
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

        public async Task<JourneyDto> UpdateJourney(int id, JourneyDto journeyDTO)
        {
            Journey journey = _mapper.Map<Journey>(journeyDTO);
            await _journeyRepository.UpdateJourney(journey);
            await DeleteRemovedLocations(journeyDTO);
            return _mapper.Map<JourneyDto>(journey);
        }

        public async Task<IEnumerable<JourneyDto>> SearchJourney(SearchJourneyDto parameters)
        {
            List<Journey> journeys =
                _query.SetBaseJourneyInfo()
                .GetJourneysDependsOnCurrentUser(parameters.UserId, parameters.IsForCurrentUser)
                .SetJourneyPrice(parameters.StartPrice, parameters.EndPrice)
                .SetJourneyRequiredAge(parameters.MinAge, parameters.MaxAge)
                .Build()
                .ToList();
                
            return _mapper.Map<IEnumerable<JourneyDto>>(GetAvailableJourneys(journeys, parameters));
        }

        private async Task DeleteRequestsByJourneyId(int journeyId)
        {
            IEnumerable<JourneyRequest> requests = await _journeyRequestRepository.GetAll();
            foreach (var request in requests)
            {
                if (request.RequestedJourneyId == journeyId)
                {
                    await _journeyRequestRepository.Delete(request);
                }
            }
            await _journeyRequestRepository.Save();
        }

        private List<Journey> GetAvailableJourneys(List<Journey> journeys, SearchJourneyDto parameters)
        {
            var res = journeys.Where(j =>
                !j.UserJourneys[0].AppUser.JourneyRequests
                .Exists(jr => jr.OrganizerId == j.OrganizerId
                && jr.RequestedJourneyId == j.Id
                && jr.RequestUserId == parameters.UserId));
            if (parameters.IsForCurrentUser)
            {
                return res.ToList();
            }
            return res.Where(j => j.AvailablePlaces > 0).ToList();
        }

        private async Task DeleteRemovedLocations(JourneyDto journeyDTO)
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
                        rl.Location.RouteLocations = null;
                        await _locationRepository.Delete(rl.Location);
                    }
                }
                await _locationRepository.Save();
            }
        }
    }
}
