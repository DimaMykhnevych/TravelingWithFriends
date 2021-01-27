using AutoMapper;
using FriendsTraveling.BusinessLayer.DTOs.JourneyDTO;
using FriendsTraveling.DataLayer.Models;
using FriendsTraveling.DataLayer.Repositories.JourneyRepository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendsTraveling.BusinessLayer.Services.JourneyService
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

        public async Task<JourneyDTO> AddJourney(JourneyDTO journeyDTO)
        {
            Journey journey = _mapper.Map<Journey>(journeyDTO);
            await _journeyRepository.Insert(journey);
            await _journeyRepository.Save();

            return _mapper.Map<JourneyDTO>(journey);
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

        public async Task<JourneyDTO> GetJourneyById(int id)
        {
            Journey journey = await _journeyRepository.Get(id);
            return _mapper.Map<JourneyDTO>(journey);
        }

        public async Task<IEnumerable<JourneyDTO>> GetJourneys()
        {
            IEnumerable<Journey> journeys = await _journeyRepository.GetAll();
            return _mapper.Map<IEnumerable<JourneyDTO>>(journeys);
        }

        public async Task<JourneyDTO> UpdateJourney(int id, JourneyDTO journeyDTO)
        {
            Journey journey = _mapper.Map<Journey>(journeyDTO);
            journey.Id = id;
            await _journeyRepository.Update(journey);
            return _mapper.Map<JourneyDTO>(journey);
        }
    }
}
