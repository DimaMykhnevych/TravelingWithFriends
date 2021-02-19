using FriendsTraveling.BusinessLayer.Constants;
using FriendsTraveling.BusinessLayer.DTOs;
using FriendsTraveling.BusinessLayer.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FriendsTraveling.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JourneyController : ControllerBase
    {
        private readonly IJourneyService _journeyService;
        private readonly IAddJourneyService _addJourneyService;
        public JourneyController(IJourneyService journeyService, IAddJourneyService addJourneyService)
        {
            _journeyService = journeyService;
            _addJourneyService = addJourneyService;
        }

        [HttpGet]
        public IActionResult GetJourneys([FromQuery] SearchJourneyDto searchJourneyDto)
        {
            int userId = Convert.ToInt32(User.FindFirstValue(AuthorizationConstants.ID));
            searchJourneyDto.UserId = userId;
            IEnumerable<JourneyDto> journey = _journeyService.SearchJourney(searchJourneyDto);
            return Ok(journey);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetJourney(int id)
        {
            JourneyDto journey = await _journeyService.GetJourneyById(id);
            if (journey == null)
                return NotFound();
            return Ok(journey);
        }

        [HttpPost]
        public async Task<IActionResult> AddJourney([FromBody] JourneyDto journeyDTO)
        {
            JourneyDto added = await _addJourneyService.AddJourney(journeyDTO, User.Identity.Name);
            if (added == null)
                return BadRequest();
            return Ok(added);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateJourney(int id, JourneyDto journeyDTO)
        {
            JourneyDto journeyToUpdate = await _journeyService.UpdateJourney(id, journeyDTO, User.Identity.Name);
            if (journeyToUpdate == null)
            {
                return NotFound();
            }
            return Ok(journeyToUpdate);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJourney(int id)
        {
            bool deleted = await _journeyService.DeleteJourney(id);
            return Ok(deleted);
        }
    }
}
