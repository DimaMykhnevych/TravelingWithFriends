using FriendsTraveling.BusinessLayer.DTOs;
using FriendsTraveling.BusinessLayer.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
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
    }
}
