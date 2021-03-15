using AutoMapper;
using FriendsTraveling.BusinessLayer.DTOs;
using FriendsTraveling.BusinessLayer.Services.Abstract;
using FriendsTraveling.DataLayer.Enums;
using FriendsTraveling.DataLayer.Models;
using FriendsTraveling.DataLayer.Models.User;
using FriendsTraveling.DataLayer.Repositories.Abstract;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendsTraveling.BusinessLayer.Services.Concrete
{
    public class JourneyRequestService : IJourneyRequestService
    {
        private readonly IJourneyRequestRepository _journeyRequestRepository;
        private readonly IMapper _mapper;
        private readonly IJourneyService _journeyService;
        private readonly IChatRepository _chatRepository;
        private readonly IUserChatRepository _userChatRepository;
        public JourneyRequestService(IJourneyRequestRepository journeyRequestRepository,
            IMapper mapper, IJourneyService journeyService, IChatRepository chatRepository,
            IUserChatRepository userChatRepository)
        {
            _journeyRequestRepository = journeyRequestRepository;
            _mapper = mapper;
            _journeyService = journeyService;
            _chatRepository = chatRepository;
            _userChatRepository = userChatRepository;
        }
        public async Task<AddJourneyRequestDto> AddJourneyRequest(AddJourneyRequestDto addJourneyRequestDto)
        {
            JourneyRequest jr = _mapper.Map<JourneyRequest>(addJourneyRequestDto);
            await _journeyRequestRepository.Insert(jr);
            await _journeyRequestRepository.Save();
            await DecreaseOrIncreaseRequestedJourneyAvailablePlaces(
                addJourneyRequestDto.RequestedJourneyId, true);
            Chat chat = await _chatRepository.GetChatByJourneyId(addJourneyRequestDto.RequestedJourneyId);
            await _userChatRepository.Insert(
                new UserChat()
                {
                    AppUserId = addJourneyRequestDto.RequestUserId,
                    ChatId = chat.Id
                });
            await _userChatRepository.Save();
            return _mapper.Map<AddJourneyRequestDto>(jr);
        }

        public async Task<bool> DeleteRequestById(int id)
        {
            JourneyRequest journeyRequestToDelete = await _journeyRequestRepository.Get(id);
            if (journeyRequestToDelete == null) return false;
            if (journeyRequestToDelete.JourneyRequestStatus != JourneyRequestStatus.canceled)
            {
                await DecreaseOrIncreaseRequestedJourneyAvailablePlaces
                    (journeyRequestToDelete.RequestedJourneyId);
            }
            await _journeyRequestRepository.Delete(journeyRequestToDelete);
            await _journeyRequestRepository.Save();

            return true;
        }

        public async Task<JourneyRequestDto> GetRequestByJourneyId(int journeyId)
        {
            JourneyRequest jr = await _journeyRequestRepository.GetRequestByJourneyId(journeyId);
            return _mapper.Map<JourneyRequestDto>(jr);
        }

        public async Task<IEnumerable<ReviewJourneyRequestDto>> GetUserInboxRequests(int userId)
        {
            IEnumerable<JourneyRequest> userInbocRequests =
                await _journeyRequestRepository.GetUserInboxRequests(userId);
            return await IncludeJourneysToRequests(userInbocRequests);
        }

        public async Task<IEnumerable<ReviewJourneyRequestDto>> GetUserRequestsWithJourneys(
            int requestedUserId)
        {
            IEnumerable<JourneyRequest> userRequests =
                await _journeyRequestRepository.GetUserRequests(requestedUserId);

            return await IncludeJourneysToRequests(userRequests);
        }
        public async Task<JourneyRequestDto> UpdateJourneyRequestStatus(
            ChangeRequestStatusDto changeRequestStatusDto)
        {
            JourneyRequest journeyRequestToUpdate =
                await _journeyRequestRepository.Get(changeRequestStatusDto.RequestId);
            if (journeyRequestToUpdate.JourneyRequestStatus != JourneyRequestStatus.pending
               && changeRequestStatusDto.NewStatus == JourneyRequestStatus.pending)
            {
                return null;
            }
            journeyRequestToUpdate.JourneyRequestStatus = changeRequestStatusDto.NewStatus;
            await OnRequestStatusChanged(journeyRequestToUpdate.RequestedJourneyId,
                changeRequestStatusDto.NewStatus);
            await _journeyRequestRepository.Update(journeyRequestToUpdate);
            await _journeyRequestRepository.Save();
            return _mapper.Map<JourneyRequestDto>(journeyRequestToUpdate);
        }

        private async Task OnRequestStatusChanged(int journeyId, JourneyRequestStatus status)
        {
            switch (status)
            {
                case JourneyRequestStatus.canceled:
                    await DecreaseOrIncreaseRequestedJourneyAvailablePlaces(journeyId);
                    break;
            }
        }

        private async Task<IEnumerable<ReviewJourneyRequestDto>> IncludeJourneysToRequests(
            IEnumerable<JourneyRequest> userRequests)
        {
            IEnumerable<ReviewJourneyRequestDto> reviewJourneyRequests =
               _mapper.Map<IEnumerable<ReviewJourneyRequestDto>>(userRequests);
            foreach (var jr in reviewJourneyRequests)
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
