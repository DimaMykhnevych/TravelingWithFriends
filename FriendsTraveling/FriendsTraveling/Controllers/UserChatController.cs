using FriendsTraveling.BusinessLayer.Services.Abstract;
using FriendsTraveling.DataLayer.Models.User;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendsTraveling.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserChatController : ControllerBase
    {
        private readonly IUserChatService _userChatService;
        public UserChatController(IUserChatService userChatService)
        {
            _userChatService = userChatService;
        }

        [HttpGet("{chatId}")]
        public async Task<IActionResult> GetChatParticipants(int chatId)
        {
            IEnumerable<AppUser> users = await _userChatService.GetChatParticipants(chatId);
            return Ok(users);
        }
    }
}
