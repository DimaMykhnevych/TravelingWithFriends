using FriendsTraveling.BusinessLayer.DTOs;
using FriendsTraveling.BusinessLayer.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendsTraveling.Web.Controllers
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
            IEnumerable<RouteDto> routes = await _routeService.GetRoutes();
            return Ok(routes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoute(int id)
        {
            RouteDto route = await _routeService.GetRouteById(id);
            if (route == null)
                return NotFound();
            return Ok(route);
        }

        [HttpPost]
        public async Task<IActionResult> AddRoute([FromBody] RouteDto routeDTO)
        {
            RouteDto added = await _routeService.AddRoute(routeDTO);
            if (added == null)
                return BadRequest();
            return Ok(added);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoute(int id, RouteDto routeDTO)
        {
            RouteDto updatedRoute = await _routeService.UpdateRoute(id, routeDTO);
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
