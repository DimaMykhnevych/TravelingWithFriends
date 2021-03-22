using FriendsTraveling.BusinessLayer.Services.Abstract;
using FriendsTraveling.DataLayer.Models.User;
using FriendsTraveling.DataLayer.Repositories.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendsTraveling.BusinessLayer.Services.Concrete
{
    public class UserChatService : IUserChatService
    {
        private readonly IUserChatRepository _userChatRepository;
        public UserChatService(IUserChatRepository userChatRepository)
        {
            _userChatRepository = userChatRepository;
        }
        public async Task<IEnumerable<AppUser>> GetChatParticipants(int chatId)
        {
            return await _userChatRepository.GetChatParticipants(chatId);
        }
    }
}
