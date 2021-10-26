using HW2_RenACar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2_RenACar.Domain.Repositories.Dapper
{
    public interface IDapperCarRepository : IDapperRepository
    {
        Task<IEnumerable<Car>> GetAllCarAsync();
        Task<Car> GetByIdCarAsync(int id);
        Task AddCarAsync(Car car);
        void RemoveCar(Car car);
        Car UpdateCar(Car car);
    }
}
