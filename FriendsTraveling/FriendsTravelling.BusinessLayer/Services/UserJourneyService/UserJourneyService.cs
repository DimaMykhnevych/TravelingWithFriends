using AutoMapper;
using FriendsTraveling.BusinessLayer.DTOs.UserJourneyDTOs;
using FriendsTraveling.DataLayer.Models;
using FriendsTraveling.DataLayer.Repositories.UserJourneyRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendsTraveling.BusinessLayer.Services.UserJourneyService
{
    public class UserJourneyService : IUserJourneyService
    {
        private readonly IUserJourneyRepository _userJourneyRepository;
        private readonly IMapper _mapper;

        public UserJourneyService(IUserJourneyRepository userJourneyRepository, IMapper mapper)
        {
            _userJourneyRepository = userJourneyRepository;
            _mapper = mapper;
        }

        public async Task<UserJourneyDTO> AddUserJourney(UserJourneyDTO userJourneyDTO)
        {
            UserJourney userJourney = _mapper.Map<UserJourney>(userJourneyDTO);
            await _userJourneyRepository.Insert(userJourney);
            await _userJourneyRepository.Save();

            return _mapper.Map<UserJourneyDTO>(userJourney);
        }

        public async Task<bool> DeleteUserJourney(int id)
        {
            UserJourney userJourneyToDelete = await _userJourneyRepository.Get(id);
            if (userJourneyToDelete == null)
                return false;
            await _userJourneyRepository.Delete(userJourneyToDelete);
            await _userJourneyRepository.Save();
            return true;
        }

        public async Task<UserJourneyDTO> GetUserJourneyById(int id)
        {
            UserJourney userJourney = await _userJourneyRepository.Get(id);
            return _mapper.Map<UserJourneyDTO>(userJourney);
        }

        public async Task<IEnumerable<UserJourneyDTO>> GetUserJourneys()
        {
            IEnumerable<UserJourney> userJourneys = await _userJourneyRepository.GetAll();
            return _mapper.Map<IEnumerable<UserJourneyDTO>>(userJourneys);
        }

        public async Task<UserJourneyDTO> UpdateUserJourney(int id, UserJourneyDTO userJourneyDTO)
        {
            UserJourney userJourney = _mapper.Map<UserJourney>(userJourneyDTO);
            userJourney.Id = id;
            await _userJourneyRepository.Update(userJourney);
            return _mapper.Map<UserJourneyDTO>(userJourney);
        }
    }
}
