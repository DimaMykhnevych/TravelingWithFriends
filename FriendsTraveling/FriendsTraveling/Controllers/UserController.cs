using FriendsTraveling.BusinessLayer.Constants;
using FriendsTraveling.BusinessLayer.DTOs;
using FriendsTraveling.BusinessLayer.Exceptions;
using FriendsTraveling.BusinessLayer.Services.Abstract;
using FriendsTraveling.DataLayer.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Threading.Tasks;

namespace FriendsTraveling.Web.Controllers
{
    [Route("api/[controller]")]
    
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }

        //[HttpGet("{username}")]
        //public async Task<IActionResult> Get(string username)
        //{
        //    return Ok(await _service.GetUserByUsername(username));
        //}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id != 0)
            {
                AppUser user = await _service.GetAllUserInfoById(id);
                if (user != null)
                {
                    return Ok(user);
                }
            }
            else
            {
                AppUser user = await _service.GetUserByUsername(User.Identity.Name);
                return Ok(user);
            }
            return NotFound();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] CreateUserModel model)
        {
            model.Role = "User";
            try
            {
                return Ok(await _service.CreateUserAsync(model));
            }
            catch (UsernameAlreadyTakenException)
            {
                return BadRequest(AddModelStateError("username", ErrorMessagesConstants.USERNAME_ALREADY_TAKEN));
            }
        }

        [HttpPost("confirmEmail")]
        public async Task<IActionResult> ConfirmEmail([FromBody] ConfirmEmailDto confirmEmailDto)
        {
            ConfirmEmailDto confirmEmail = await _service.ConfirmEmail(confirmEmailDto);
            if(confirmEmail == null)
                return BadRequest("Invalid Email Confirmation Request");
            return Ok(confirmEmail);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateUserProfile([FromBody] UpdateUserProfileDto userProfileDTO)
        {
            try
            {
                return Ok(await _service.UpdateUserProfileAsync(userProfileDTO));
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
        //public async Task<IActionResult> Put([FromBody] UpdateUserModel model)
        //{
        //    try
        //    {
        //        return Ok(await _service.UpdateUserAsync(model));
        //    }
        //    catch (InvalidUserPasswordException)
        //    {
        //        return BadRequest(AddModelStateError("password", ErrorMessagesConstants.INVALID_PASSWORD));
        //    }
        //    catch (UsernameAlreadyTakenException)
        //    {
        //        return BadRequest(AddModelStateError("username", ErrorMessagesConstants.USERNAME_ALREADY_TAKEN));
        //    }
        //}


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
