using AutoMapper;
using HW2_RenACar.Domain.Entities;
using HW2_RenACar.Domain.Repositories.Dapper;
using HW2_RenACar.Domain.Repositories.EntityFrameworkCore;
using HW2_RentACar.Application.DTOs;
using HW2_RentACar.Application.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2_RentACar.Application.Services
{
    public class RentService : IRentService
    {
        private readonly IDapperRentRepository _dapperRentRepository;
        private readonly IMapper _mapper;
        
        public RentService(IDapperRentRepository dapperRentRepository, IMapper mapper)
        {
            _dapperRentRepository = dapperRentRepository;
            _mapper = mapper;
        }

        public async Task AddRentAsync(RentDto rent)
        {
            await _dapperRentRepository.AddRentAsync(_mapper.Map<Rent>(rent));
        }

        public async Task<IEnumerable<RentDto>> GetAllRentAsync()
        {
            return _mapper.Map<IEnumerable<RentDto>>(await _dapperRentRepository.GetAllRentAsync());
        }

        public async Task<RentDto> GetByIdAsync(int rentId)
        {
            return _mapper.Map<RentDto>(await _dapperRentRepository.GetByIdAsync(rentId));
        }

        public void RemoveRent(RentDto rent)
        {
            _dapperRentRepository.RemoveRent(_mapper.Map<Rent>(rent));
        }

        public RentDto UpdateRent(RentDto rent)
        {
            var result = _dapperRentRepository.UpdateRent(_mapper.Map<Rent>(rent));
            return _mapper.Map<RentDto>(result);
        }
        
    }
}
