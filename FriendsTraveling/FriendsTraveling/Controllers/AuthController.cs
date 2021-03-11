using FriendsTraveling.BusinessLayer.Services.Abstract;
using FriendsTraveling.DataLayer.Models.Auth;
using FriendsTraveling.DataLayer.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FriendsTraveling.Web.Controllers
{
    [Route("api/[controller]")]

    public class AuthController : ControllerBase
    {

        private readonly BaseAuthorizationService _authorizationService;
        private readonly IEmailService _emailService;
        private readonly UserManager<AppUser> _userManager;
        public AuthController(BaseAuthorizationService authorizationService, 
            IEmailService emailService, UserManager<AppUser> userManager)
        {
            _authorizationService = authorizationService;
            _emailService = emailService;
            _userManager = userManager;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("token")]
        public async Task<IActionResult> Login([FromBody] AuthSignInModel model)
        {
            JWTTokenStatusResult result = await _authorizationService.GenerateTokenAsync(model);
            //AppUser user = await _userManager.FindByNameAsync(model.UserName);
            //await _emailService.SendTicketEmail(user);

            return Ok(result);
        }

        [HttpGet]
        [Route("user-info")]
        [Authorize(Roles = Role.User + "," + Role.Admin)]
        public async Task<IActionResult> GetUserInfo()
        {
            string currentUserName = User.Identity.Name;
            UserAuthInfo userInfo = await _authorizationService.GetUserInfoAsync(currentUserName);

            if (userInfo == null)
            {
                return NotFound();
            }

            return Ok(userInfo);
        }
    }
}
