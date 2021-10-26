using HW2_RentACar.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2_RentACar.Application.ServiceInterfaces
{
    public interface ICarService
    {
        Task<IEnumerable<CarDto>> GetAllCarAsync();
        Task AddCarAsync(CarDto car);
        Task<CarDto> GetByIdAsync(int carId);
        void RemoveCar(CarDto car);
        CarDto UpdateCar(CarDto car);
    }
}
