using FriendsTraveling.BusinessLayer.DTOs.RouteDTOs;
using FriendsTraveling.BusinessLayer.Services.RouteService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendsTraveling.Controllers.RouteController
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        private readonly IRouteService _routeService;
        public RouteController(IRouteService routeService)
        {
            _routeService = routeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRoutes()
        {
            IEnumerable<RouteDTO> routes = await _routeService.GetRoutes();
            return Ok(routes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoute(int id)
        {
            RouteDTO route = await _routeService.GetRouteById(id);
            if (route == null)
                return NotFound();
            return Ok(route);
        }

        [HttpPost]
        public async Task<IActionResult> AddRoute([FromBody] RouteDTO routeDTO)
        {
            RouteDTO added = await _routeService.AddRoute(routeDTO);
            if (added == null)
                return BadRequest();
            return Ok(added);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoute(int id, RouteDTO routeDTO)
        {
            RouteDTO updatedRoute = await _routeService.UpdateRoute(id, routeDTO);
            if (updatedRoute == null)
            {
                return NotFound();
            }
            return Ok(updatedRoute);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoute(int id)
        {
            bool deleted = await _routeService.DeleteRoute(id);
            return Ok(deleted);
        }
    }
}
