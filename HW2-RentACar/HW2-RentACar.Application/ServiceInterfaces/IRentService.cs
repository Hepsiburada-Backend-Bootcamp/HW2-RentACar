using HW2_RentACar.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2_RentACar.Application.ServiceInterfaces
{
    public interface IRentService
    {
        Task<IEnumerable<RentDto>> GetAllRentAsync();
        Task AddRentAsync(RentDto rent);
        void RemoveRent(RentDto rent);
        RentDto UpdateRent(RentDto rent);
        Task<RentDto> GetByIdAsync(int rentId);
    }
}
