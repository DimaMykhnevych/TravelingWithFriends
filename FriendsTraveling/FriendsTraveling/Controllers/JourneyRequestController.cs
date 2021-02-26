using FriendsTraveling.BusinessLayer.DTOs;
using FriendsTraveling.BusinessLayer.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendsTraveling.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JourneyRequestController : ControllerBase
    {
        private readonly IJourneyRequestService _journeyRequestService;
        public JourneyRequestController(IJourneyRequestService journeyRequestService)
        {
            _journeyRequestService = journeyRequestService;
        }

        [HttpGet("requestsWithJourneys/{requestedUserId}")]
        public async Task<IActionResult> GetUserRequestsWithJourneys(int requestedUserId) {
            IEnumerable<ReviewJourneyRequestDto> reviewJourneyRequests =
               await  _journeyRequestService.GetUserRequestsWithJourneys(requestedUserId);
            return Ok(reviewJourneyRequests);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRequestByJourneyId(int id)
        {
            JourneyRequestDto jr = await _journeyRequestService.GetRequestByJourneyId(id);
            return Ok(jr);
        }

        [HttpPost]
        public async Task<IActionResult> AddJourneyRequest([FromBody] AddJourneyRequestDto addJourneyRequestDto)
        {
            AddJourneyRequestDto added = 
                await _journeyRequestService.AddJourneyRequest(addJourneyRequestDto);
            if (added == null)
                return BadRequest();
            return Ok(added);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequest(int id)
        {
            bool deleted = await _journeyRequestService.DeleteRequestById(id);
            return Ok(deleted);
        }
    }
}
