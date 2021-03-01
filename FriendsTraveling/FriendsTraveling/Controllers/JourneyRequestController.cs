using FriendsTraveling.BusinessLayer.DTOs;
using FriendsTraveling.BusinessLayer.HubN;
using FriendsTraveling.BusinessLayer.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendsTraveling.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JourneyRequestController : ControllerBase
    {
        private readonly IJourneyRequestService _journeyRequestService;
        private readonly IHubContext<JourneyRequestHub> _hub;
        public JourneyRequestController(
            IJourneyRequestService journeyRequestService,
            IHubContext<JourneyRequestHub> hub)
        {
            _journeyRequestService = journeyRequestService;
            _hub = hub;
        }

        [HttpGet("requestsWithJourneys/{requestedUserId}")]
        public async Task<IActionResult> GetUserRequestsWithJourneys(int requestedUserId) {
            IEnumerable<ReviewJourneyRequestDto> reviewJourneyRequests =
               await  _journeyRequestService.GetUserRequestsWithJourneys(requestedUserId);
            return Ok(reviewJourneyRequests);
        }

        [HttpGet("userInboxRequests/{userId}")]
        public async Task<IActionResult> GetUserInboxRequests(int userId)
        {
            IEnumerable<ReviewJourneyRequestDto> reviewJourneyInboxRequests =
               await _journeyRequestService.GetUserInboxRequests(userId);
            return Ok(reviewJourneyInboxRequests);
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
            await _hub.Clients.All.SendAsync("requestsChanged", "request added");
            return Ok(added);
        }

        [HttpPut]
        public async Task<IActionResult> ChangeJourneyRequestStatus(
            [FromBody] ChangeRequestStatusDto changeRequestStatusDto)
        {
            JourneyRequestDto updatedJourneyRequest = 
                await _journeyRequestService.UpdateJourneyRequestStatus(changeRequestStatusDto);
            if (updatedJourneyRequest == null)
                return BadRequest();
            await _hub.Clients.All.SendAsync("requestsChanged", "request staus changed");
            return Ok(updatedJourneyRequest);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequest(int id)
        {
            bool deleted = await _journeyRequestService.DeleteRequestById(id);
            await _hub.Clients.All.SendAsync("requestsChanged", "request deleted");

            return Ok(deleted);
        }
    }
}
