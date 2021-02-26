using AutoMapper;
using FriendsTraveling.BusinessLayer.DTOs;
using FriendsTraveling.BusinessLayer.Services.Abstract;
using FriendsTraveling.DataLayer.Models;
using FriendsTraveling.DataLayer.Repositories.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendsTraveling.BusinessLayer.Services.Concrete
{
    public class JourneyRequestService : IJourneyRequestService
    {
        private readonly IJourneyRequestRepository _journeyRequestRepository;
        private readonly IMapper _mapper;
        private readonly IJourneyService _journeyService;
        public JourneyRequestService(IJourneyRequestRepository journeyRequestRepository,
            IMapper mapper, IJourneyService journeyService)
        {
            _journeyRequestRepository = journeyRequestRepository;
            _mapper = mapper;
            _journeyService = journeyService;
        }
        public async Task<AddJourneyRequestDto> AddJourneyRequest(AddJourneyRequestDto addJourneyRequestDto)
        {
            JourneyRequest jr = _mapper.Map<JourneyRequest>(addJourneyRequestDto);
            await _journeyRequestRepository.Insert(jr);
            await _journeyRequestRepository.Save();
            await DecreaseOrIncreaseRequestedJourneyAvailablePlaces(
                addJourneyRequestDto.RequestedJourneyId, true);
            return _mapper.Map<AddJourneyRequestDto>(jr);
        }

        public async Task<bool> DeleteRequestById(int id)
        {
            JourneyRequest journeyRequestToDelete = await _journeyRequestRepository.Get(id);
            if (journeyRequestToDelete == null) return false;
            await DecreaseOrIncreaseRequestedJourneyAvailablePlaces(journeyRequestToDelete.RequestedJourneyId);
            await _journeyRequestRepository.Delete(journeyRequestToDelete);
            await _journeyRequestRepository.Save();
            return true;
        }

        public async Task<JourneyRequestDto> GetRequestByJourneyId(int journeyId)
        {
            JourneyRequest jr = await _journeyRequestRepository.GetRequestByJourneyId(journeyId);
            return _mapper.Map<JourneyRequestDto>(jr);
        }

        public async Task<IEnumerable<ReviewJourneyRequestDto>> GetUserRequestsWithJourneys(int requestedUserId)
        {
            IEnumerable<JourneyRequest> userRequests =
                await _journeyRequestRepository.GetUserRequests(requestedUserId);
            IEnumerable<ReviewJourneyRequestDto> reviewJourneyRequests = 
                _mapper.Map<IEnumerable<ReviewJourneyRequestDto>>(userRequests);
            foreach(var jr in reviewJourneyRequests)
            {
                jr.Journey = await _journeyService.GetJourneyById(jr.RequestedJourneyId);
                jr.Journey.UserJourneys = null;
            }
            return reviewJourneyRequests;
        }


        private async Task DecreaseOrIncreaseRequestedJourneyAvailablePlaces(int journeyId, 
            bool decrease = false)
        {
            JourneyDto requestedJourney = await _journeyService.GetJourneyById(journeyId);
            requestedJourney.UserJourneys = null;
            if (decrease)
            {
                requestedJourney.AvailablePlaces--;
            }
            else
            {
                requestedJourney.AvailablePlaces++;
            }
            await _journeyService.UpdateJourney(journeyId, requestedJourney);
        }
    }
}
