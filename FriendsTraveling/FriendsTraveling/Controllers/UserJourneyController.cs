using FriendsTraveling.BusinessLayer.DTOs;
using FriendsTraveling.BusinessLayer.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendsTraveling.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserJourneyController : ControllerBase
    {
        private readonly IUserJourneyService _userJourneyService;
        public UserJourneyController(IUserJourneyService userJourneyService)
        {
            _userJourneyService = userJourneyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserJourneys()
        {
            IEnumerable<UserJourneyDto> userJourneys = await _userJourneyService.GetUserJourneys();
            return Ok(userJourneys);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserJourney(int id)
        {
            UserJourneyDto userJourney = await _userJourneyService.GetUserJourneyById(id);
            if (userJourney == null)
                return NotFound();
            return Ok(userJourney);
        }

        [HttpPost]
        public async Task<IActionResult> AddUserJourney([FromBody] UserJourneyDto userJourneyDTO)
        {
            UserJourneyDto added = await _userJourneyService.AddUserJourney(userJourneyDTO);
            if (added == null)
                return BadRequest();
            return Ok(added);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserJourney(int id, UserJourneyDto userJourneyDTO)
        {
            UserJourneyDto updatedUserJourney = await _userJourneyService.UpdateUserJourney(id, userJourneyDTO);
            if (updatedUserJourney == null)
            {
                return NotFound();
            }
            return Ok(updatedUserJourney);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserJourney(int id)
        {
            bool deleted = await _userJourneyService.DeleteUserJourney(id);
            return Ok(deleted);
        }
    }
}
