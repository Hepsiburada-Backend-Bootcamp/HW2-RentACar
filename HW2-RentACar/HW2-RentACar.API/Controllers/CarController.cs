using HW2_RenACar.Domain.Repositories.Dapper;
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
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _carService.GetAllCarAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _carService.GetByIdAsync(id);

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
        public async Task<IActionResult> AddAsync([FromBody] CarDto car)
        {
            await _carService.AddCarAsync(car);
            return NoContent();
        }

        [HttpPut]
        public IActionResult UpdateCar([FromBody] CarDto car)
        {
            var result = _carService.UpdateCar(car);
            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return NoContent();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCar(int id)
        {
            var model = await _carService.GetByIdAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            else
            {
                _carService.RemoveCar(model);
                return NoContent();
            }
            
        }
    }
}
