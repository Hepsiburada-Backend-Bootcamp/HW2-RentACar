using AutoMapper;
using HW2_RenACar.Domain.Entities;
using HW2_RenACar.Domain.Repositories.Dapper;
using HW2_RentACar.Application.DTOs;
using HW2_RentACar.Application.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2_RentACar.Application.Services
{
    public class CarService : ICarService
    {
        private readonly IDapperCarRepository _dapperCarRepository;
        private readonly IMapper _mapper;

        public CarService(IDapperCarRepository dapperCarRepository, IMapper mapper)
        {
            _dapperCarRepository = dapperCarRepository;
            _mapper = mapper;
        }

        public async Task AddCarAsync(CarDto car)
        {
            await _dapperCarRepository.AddCarAsync(_mapper.Map<Car>(car));
        }

        public async Task<IEnumerable<CarDto>> GetAllCarAsync()
        {
            return _mapper.Map<IEnumerable<CarDto>>(await _dapperCarRepository.GetAllCarAsync());
        }

        public async Task<CarDto> GetByIdAsync(int carId)
        {
            return _mapper.Map<CarDto>(await _dapperCarRepository.GetByIdCarAsync(carId));
        }

        public void RemoveCar(CarDto car)
        {
            _dapperCarRepository.RemoveCar(_mapper.Map<Car>(car));
        }

        public CarDto UpdateCar(CarDto car)
        {
            var result = _dapperCarRepository.UpdateCar(_mapper.Map<Car>(car));
            return _mapper.Map<CarDto>(car);
        }
    }
}
