using FriendsTraveling.BusinessLayer.DTOs;
using FriendsTraveling.BusinessLayer.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        public async Task<IActionResult> GetJourneys([FromQuery] bool isForCurrentUser)
        {
            IEnumerable<JourneyDto> journey;
            if (isForCurrentUser)
            {
               journey = await _journeyService.GetCurrentUserJourneys(User.Identity.Name);
            }
            else
            {
                journey = await _journeyService.GetJourneys();
            }
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
        public async Task<IActionResult> AddJourney([FromBody] AddJourneyDto journeyDTO)
        {
            JourneyDto added = await _addJourneyService.AddJourney(journeyDTO, User.Identity.Name);
            if (added == null)
                return BadRequest();
            return Ok(added);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateJourney(int id, JourneyDto journeyDTO)
        {
            JourneyDto journeyToUpdate = await _journeyService.UpdateJourney(id, journeyDTO);
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
