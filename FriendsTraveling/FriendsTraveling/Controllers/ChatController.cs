using FriendsTraveling.BusinessLayer.DTOs;
using FriendsTraveling.BusinessLayer.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendsTraveling.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IChatService _chatService;

        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpGet("userChats/{id}")]
        public async Task<IActionResult> GetUserChats(int id)
        {
            IEnumerable<ChatDto> chats = await _chatService.GetUserChats(id);
            return Ok(chats);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetChatById(int id)
        {
            string username = User.Identity.Name;
            ChatDto chat = await _chatService.GetChatById(id, username);
            if (chat != null)
            {
                return Ok(chat);
            }
            return NotFound();
        }

    }
}
