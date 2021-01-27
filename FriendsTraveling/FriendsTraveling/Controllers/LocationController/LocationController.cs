using FriendsTraveling.BusinessLayer.DTOs.LocationDTOs;
using FriendsTraveling.BusinessLayer.Services.LocationService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendsTraveling.Controllers.LocationController
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
            IEnumerable<LocationDTO> locations = await _locationService.GetLocations();
            return Ok(locations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocation(int id)
        {
            LocationDTO location = await _locationService.GetLocationById(id);
            if (location == null)
                return NotFound();
            return Ok(location);
        }

        [HttpPost]
        public async Task<IActionResult> AddLocation([FromBody] LocationDTO locationDTO)
        {
            LocationDTO added = await _locationService.AddLocation(locationDTO);
            if (added == null)
                return BadRequest();
            return Ok(added);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLocation(int id, LocationDTO locationDTO)
        {
            LocationDTO updatedLocation = await _locationService.UpdateLocation(id, locationDTO);
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
