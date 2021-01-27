using FriendsTraveling.BusinessLayer.DTOs.UserJourneyDTOs;
using FriendsTraveling.BusinessLayer.Services.UserJourneyService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FriendsTraveling.Controllers.UserJourneyController
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
            IEnumerable<UserJourneyDTO> userJourneys = await _userJourneyService.GetUserJourneys();
            return Ok(userJourneys);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserJourney(int id)
        {
            UserJourneyDTO userJourney = await _userJourneyService.GetUserJourneyById(id);
            if (userJourney == null)
                return NotFound();
            return Ok(userJourney);
        }

        [HttpPost]
        public async Task<IActionResult> AddUserJourney([FromBody] UserJourneyDTO userJourneyDTO)
        {
            UserJourneyDTO added = await _userJourneyService.AddUserJourney(userJourneyDTO);
            if (added == null)
                return BadRequest();
            return Ok(added);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserJourney(int id, UserJourneyDTO userJourneyDTO)
        {
            UserJourneyDTO updatedUserJourney = await _userJourneyService.UpdateUserJourney(id, userJourneyDTO);
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
