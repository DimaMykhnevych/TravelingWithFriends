using FriendsTraveling.BusinessLayer.DTOs.RouteLocationDTOs;
using FriendsTraveling.BusinessLayer.Services.RouteLocationService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendsTraveling.Controllers.RouteLocationController
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteLocationController : ControllerBase
    {
        private readonly IRouteLocationService _routeLocationService;
        public RouteLocationController(IRouteLocationService routeLocationService)
        {
            _routeLocationService = routeLocationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRouteLocations()
        {
            IEnumerable<RouteLocationDTO> routeLocations = await _routeLocationService.GetRouteLocations();
            return Ok(routeLocations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRouteLocation(int id)
        {
            RouteLocationDTO routeLocation = await _routeLocationService.GetRouteLocationById(id);
            if (routeLocation == null)
                return NotFound();
            return Ok(routeLocation);
        }

        [HttpPost]
        public async Task<IActionResult> AddRouteLocation([FromBody] RouteLocationDTO routeLocationDTO)
        {
            RouteLocationDTO added = await _routeLocationService.AddRouteLocation(routeLocationDTO);
            if (added == null)
                return BadRequest();
            return Ok(added);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRouteLocation(int id, RouteLocationDTO routeLocationDTO)
        {
            RouteLocationDTO updatedRouteLocation = await _routeLocationService.UpdateRouteLocation(id, routeLocationDTO);
            if (updatedRouteLocation == null)
            {
                return NotFound();
            }
            return Ok(updatedRouteLocation);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRouteLocation(int id)
        {
            bool deleted = await _routeLocationService.DeleteRouteLocation(id);
            return Ok(deleted);
        }
    }
}
