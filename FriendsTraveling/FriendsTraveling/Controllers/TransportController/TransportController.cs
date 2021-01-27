using FriendsTraveling.BusinessLayer.DTOs.TransportDTOs;
using FriendsTraveling.BusinessLayer.Services.TransportService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendsTraveling.Controllers.TransportController
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportController : ControllerBase
    {
        private readonly ITransportService _transportService;
        public TransportController(ITransportService transportService)
        {
            _transportService = transportService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTransports()
        {
            IEnumerable<TransportDTO> transports = await _transportService.GetTransports();
            return Ok(transports);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransport(int id)
        {
            TransportDTO transport = await _transportService.GetTransportById(id);
            if (transport == null)
                return NotFound();
            return Ok(transport);
        }

        [HttpPost]
        public async Task<IActionResult> AddTransport([FromBody] TransportDTO transportDTO)
        {
            TransportDTO added = await _transportService.AddTranspotrt(transportDTO);
            if (added == null)
                return BadRequest();
            return Ok(added);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTransport(int id, TransportDTO transportDTO)
        {
            TransportDTO updatedTransport = await _transportService.UpdateTransport(id, transportDTO);
            if(updatedTransport == null)
            {
                return NotFound();
            }
            return Ok(updatedTransport);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransport(int id)
        {
            bool deleted = await _transportService.DeleteTransport(id);
            return Ok(deleted);
        }

    }
}
