using FriendsTraveling.BusinessLayer.DTOs;
using FriendsTraveling.BusinessLayer.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendsTraveling.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;
        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetLocations()
        {
            IEnumerable<LocationDto> locations = await _locationService.GetLocations();
            return Ok(locations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocation(int id)
        {
            LocationDto location = await _locationService.GetLocationById(id);
            if (location == null)
                return NotFound();
            return Ok(location);
        }

        [HttpPost]
        public async Task<IActionResult> AddLocation([FromBody] LocationDto locationDTO)
        {
            LocationDto added = await _locationService.AddLocation(locationDTO);
            if (added == null)
                return BadRequest();
            return Ok(added);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLocation(int id, LocationDto locationDTO)
        {
            LocationDto updatedLocation = await _locationService.UpdateLocation(id, locationDTO);
            if (updatedLocation == null)
            {
                return NotFound();
            }
            return Ok(updatedLocation);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            bool deleted = await _locationService.DeleteLocation(id);
            return Ok(deleted);
        }

    }
}
