using AutoMapper;
using FriendsTraveling.BusinessLayer.DTOs;
using FriendsTraveling.BusinessLayer.Services.Abstract;
using FriendsTraveling.DataLayer.Models;
using FriendsTraveling.DataLayer.Repositories.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendsTraveling.BusinessLayer.Services.Concrete
{
    public class JourneyService : IJourneyService
    {
        private readonly IJourneyRepository _journeyRepository;
        private readonly IMapper _mapper;

        public JourneyService(IJourneyRepository journeyRepository, IMapper mapper)
        {
            _journeyRepository = journeyRepository;
            _mapper = mapper;
        }

        public async Task<JourneyDto> AddJourney(JourneyDto journeyDTO)
        {
            Journey journey = _mapper.Map<Journey>(journeyDTO);
            await _journeyRepository.Insert(journey);
            await _journeyRepository.Save();

            return _mapper.Map<JourneyDto>(journey);
        }

        public async Task<bool> DeleteJourney(int id)
        {
            Journey journeyToDelete = await _journeyRepository.Get(id);
            if (journeyToDelete == null)
                return false;
            await _journeyRepository.Delete(journeyToDelete);
            await _journeyRepository.Save();
            return true;
        }

        public async Task<JourneyDto> GetJourneyById(int id)
        {
            Journey journey = await _journeyRepository.Get(id);
            return _mapper.Map<JourneyDto>(journey);
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
