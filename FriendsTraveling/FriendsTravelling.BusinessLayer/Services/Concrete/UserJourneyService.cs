using AutoMapper;
using FriendsTraveling.BusinessLayer.DTOs;
using FriendsTraveling.BusinessLayer.Services.Abstract;
using FriendsTraveling.DataLayer.Models;
using FriendsTraveling.DataLayer.Repositories.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendsTraveling.BusinessLayer.Services.Concrete
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

        public async Task<UserJourneyDto> AddUserJourney(UserJourneyDto userJourneyDTO)
        {
            UserJourney userJourney = _mapper.Map<UserJourney>(userJourneyDTO);
            await _userJourneyRepository.Insert(userJourney);
            await _userJourneyRepository.Save();

            return _mapper.Map<UserJourneyDto>(userJourney);
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

        public async Task<UserJourneyDto> GetUserJourneyById(int id)
        {
            UserJourney userJourney = await _userJourneyRepository.Get(id);
            return _mapper.Map<UserJourneyDto>(userJourney);
        }

        public async Task<IEnumerable<UserJourneyDto>> GetUserJourneys()
        {
            IEnumerable<UserJourney> userJourneys = await _userJourneyRepository.GetAll();
            return _mapper.Map<IEnumerable<UserJourneyDto>>(userJourneys);
        }

        public async Task<UserJourneyDto> UpdateUserJourney(int id, UserJourneyDto userJourneyDTO)
        {
            UserJourney userJourney = _mapper.Map<UserJourney>(userJourneyDTO);
            userJourney.Id = id;
            await _userJourneyRepository.Update(userJourney);
            return _mapper.Map<UserJourneyDto>(userJourney);
        }
    }
}
