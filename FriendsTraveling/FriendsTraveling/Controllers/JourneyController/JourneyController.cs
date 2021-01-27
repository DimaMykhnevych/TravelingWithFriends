using FriendsTraveling.BusinessLayer.DTOs.JourneyDTO;
using FriendsTraveling.BusinessLayer.Services.JourneyService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendsTraveling.Controllers.JourneyController
{
    [Route("api/[controller]")]
    [ApiController]
    public class JourneyController : ControllerBase
    {
        private readonly IJourneyService _journeyService;
        public JourneyController(IJourneyService journeyService)
        {
            _journeyService = journeyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetJourneys()
        {
            IEnumerable<JourneyDTO> journey = await _journeyService.GetJourneys();
            return Ok(journey);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetJourney(int id)
        {
            JourneyDTO journey = await _journeyService.GetJourneyById(id);
            if (journey == null)
                return NotFound();
            return Ok(journey);
        }

        [HttpPost]
        public async Task<IActionResult> AddJourney([FromBody] JourneyDTO journeyDTO)
        {
            JourneyDTO added = await _journeyService.AddJourney(journeyDTO);
            if (added == null)
                return BadRequest();
            return Ok(added);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateJourney(int id, JourneyDTO journeyDTO)
        {
            JourneyDTO journeyToUpdate = await _journeyService.UpdateJourney(id, journeyDTO);
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
