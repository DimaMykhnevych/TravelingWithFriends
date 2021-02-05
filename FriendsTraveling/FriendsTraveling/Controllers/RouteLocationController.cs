using FriendsTraveling.BusinessLayer.DTOs;
using FriendsTraveling.BusinessLayer.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendsTraveling.Web.Controllers
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
            IEnumerable<RouteLocationDto> routeLocations = await _routeLocationService.GetRouteLocations();
            return Ok(routeLocations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRouteLocation(int id)
        {
            RouteLocationDto routeLocation = await _routeLocationService.GetRouteLocationById(id);
            if (routeLocation == null)
                return NotFound();
            return Ok(routeLocation);
        }

        [HttpPost]
        public async Task<IActionResult> AddRouteLocation([FromBody] RouteLocationDto routeLocationDTO)
        {
            RouteLocationDto added = await _routeLocationService.AddRouteLocation(routeLocationDTO);
            if (added == null)
                return BadRequest();
            return Ok(added);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRouteLocation(int id, RouteLocationDto routeLocationDTO)
        {
            RouteLocationDto updatedRouteLocation = await _routeLocationService.UpdateRouteLocation(id, routeLocationDTO);
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
