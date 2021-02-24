﻿using FriendsTraveling.BusinessLayer.DTOs;
using System.Threading.Tasks;

namespace FriendsTraveling.BusinessLayer.Services.Abstract
{
    public interface IJourneyRequestService
    {
        Task<AddJourneyRequestDto> AddJourneyRequest(AddJourneyRequestDto addJourneyRequestDto);
        Task<JourneyRequestDto> GetRequestByJourneyId(int journeyId);
        Task DeleteRequestsByJourneyId(int journeyId);
    }
}
