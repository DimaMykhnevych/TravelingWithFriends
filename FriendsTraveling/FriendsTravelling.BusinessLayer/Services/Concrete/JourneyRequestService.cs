using AutoMapper;
using FriendsTraveling.BusinessLayer.DTOs;
using FriendsTraveling.BusinessLayer.Services.Abstract;
using FriendsTraveling.DataLayer.Models;
using FriendsTraveling.DataLayer.Repositories.Abstract;
using System.Threading.Tasks;

namespace FriendsTraveling.BusinessLayer.Services.Concrete
{
    public class JourneyRequestService : IJourneyRequestService
    {
        private readonly IJourneyRequestRepository _journeyRequestRepository;
        private readonly IMapper _mapper;
        public JourneyRequestService(IJourneyRequestRepository journeyRequestRepository, IMapper mapper)
        {
            _journeyRequestRepository = journeyRequestRepository;
            _mapper = mapper;
        }
        public async Task<AddJourneyRequestDto> AddJourneyRequest(AddJourneyRequestDto addJourneyRequestDto)
        {
            JourneyRequest jr = _mapper.Map<JourneyRequest>(addJourneyRequestDto);
            await _journeyRequestRepository.Insert(jr);
            await _journeyRequestRepository.Save();
            return _mapper.Map<AddJourneyRequestDto>(jr);
        }
    }
}
