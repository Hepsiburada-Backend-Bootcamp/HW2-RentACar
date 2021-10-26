using HW2_RentACar.Application.DTOs;
using HW2_RentACar.Application.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW2_RentACar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<IActionResult> GetClientAsync()
        {
            var result = await _clientService.GetAllClientAsync();

            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClientByIdAsync(int id)
        {
            var result = await _clientService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }

        }

        [HttpPost]
        public async Task<IActionResult> AddClientAsync([FromBody] ClientDto client)
        {
            await _clientService.AddClientAsync(client);
            return NoContent();
        }

        [HttpPut]
        public IActionResult UpdateClient([FromBody] ClientDto client)
        {
            var result = _clientService.UpdateClinet(client);
            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveClient([FromRoute] int id)
        {
            var result = _clientService.GetByIdAsync(id).Result;
            if (result == null)
            {
                return NotFound();
            }
            else
            {
                _clientService.RemoveClient(result);
                return NoContent();
            }
        }

    }
}
