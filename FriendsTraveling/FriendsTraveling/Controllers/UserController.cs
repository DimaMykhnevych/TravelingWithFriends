using FriendsTraveling.BusinessLayer.Constants;
using FriendsTraveling.BusinessLayer.DTOs;
using FriendsTraveling.BusinessLayer.Exeptions;
using FriendsTraveling.BusinessLayer.Services.UserAuthorizationService.UserService;
using FriendsTraveling.DataLayer.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Threading.Tasks;

namespace FriendsTraveling.Controllers
{
    [Route("api/[controller]")]
    
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet("{username}")]
        public async Task<IActionResult> Get(string username)
        {
            return Ok(await _service.GetUserByUsername(username));
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] CreateUserModel model)
        {
            //model.Role = "User";
            try
            {
                return Ok(await _service.CreateUserAsync(model));
            }
            catch (UsernameAlreadyTakenException)
            {
                return BadRequest(AddModelStateError("username", ErrorMessagesConstants.USERNAME_ALREADY_TAKEN));
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateUserModel model)
        {
            try
            {
                return Ok(await _service.UpdateUserAsync(model));
            }
            catch (InvalidUserPasswordException)
            {
                return BadRequest(AddModelStateError("password", ErrorMessagesConstants.INVALID_PASSWORD));
            }
            catch (UsernameAlreadyTakenException)
            {
                return BadRequest(AddModelStateError("username", ErrorMessagesConstants.USERNAME_ALREADY_TAKEN));
            }
        }


        [HttpDelete("{id}")]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteUser(id);
            return Ok();
        }

        private ModelStateDictionary AddModelStateError(String field, String error)
        {
            ModelStateDictionary modelState = new ModelStateDictionary();
            modelState.TryAddModelError(field, error);
            return modelState;
        }
    }
}
