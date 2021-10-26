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
    public class RentController : ControllerBase
    {
        private readonly IRentService _rentService;

        public RentController(IRentService dapperRentService)
        {
            _rentService = dapperRentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRentAsync()
        {
            var result = await _rentService.GetAllRentAsync();

            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRentByIdAsync(int id)
        {
            var result = await _rentService.GetByIdAsync(id);
            if(result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> AddRentAsync([FromBody] RentDto rent)
        {
            await _rentService.AddRentAsync(rent);
            return NoContent();
        }

        [HttpPut]
        public IActionResult UpdateRent([FromBody] RentDto rent)
        {
            var result = _rentService.UpdateRent(rent);
            if(result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveRent([FromRoute] int id)
        {
            var result = _rentService.GetByIdAsync(id).Result;
            if (result == null)
            {
                return NotFound();
            }
            else
            {
                _rentService.RemoveRent(result);
                return NoContent();
            }
        }
    }
}
