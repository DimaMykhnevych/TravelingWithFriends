using FriendsTraveling.BusinessLayer.DTOs;
using FriendsTraveling.BusinessLayer.HubN;
using FriendsTraveling.BusinessLayer.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendsTraveling.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IHubContext<ChatHub> _chatHub;

        public MessageController(IMessageService messageService, IHubContext<ChatHub> hub)
        {
            _messageService = messageService;
            _chatHub = hub;
        }

        [HttpGet("{chatId}")]
        public async Task<IActionResult> GetChatMessages(int chatId)
        {
            IEnumerable<MessageDto> messages = await _messageService.GetChatMessages(chatId);
            return Ok(messages);
        }

        [HttpPost]
        public async Task<IActionResult> PostMessage([FromBody] MessageDto messageDto)
        {
            MessageDto message = await _messageService.PostMessage(messageDto);
            return Ok(message);
        }

    }
}
