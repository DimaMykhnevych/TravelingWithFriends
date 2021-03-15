using AutoMapper;
using FriendsTraveling.BusinessLayer.DTOs;
using FriendsTraveling.BusinessLayer.Services.Abstract;
using FriendsTraveling.DataLayer.Models;
using FriendsTraveling.DataLayer.Models.User;
using FriendsTraveling.DataLayer.Repositories.Abstract;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendsTraveling.BusinessLayer.Services.Concrete
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository _chatRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        public ChatService(IChatRepository repository, 
            IMapper mapper,
            UserManager<AppUser> userManager)
        {
            _chatRepository = repository;
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task<IEnumerable<ChatDto>> GetUserChats(int userId)
        {
            IEnumerable<Chat> chats = await _chatRepository.GetUserChats(userId);
            IEnumerable<ChatDto> chatsDto =  _mapper.Map<IEnumerable<ChatDto>>(chats);
            foreach(var c in chatsDto)
            {
                c.JourneyCreator = await _userManager.FindByIdAsync(c.Journey.OrganizerId.ToString());
            }
            return chatsDto;
        }
    }
}
