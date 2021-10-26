using HW2_RenACar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2_RenACar.Domain.Repositories.Dapper
{
    public interface IDapperRentRepository : IDapperRepository
    {
        Task<IEnumerable<Rent>> GetAllRentAsync();
        Task AddRentAsync(Rent rent);
        void RemoveRent(Rent rent);
        Rent UpdateRent(Rent rent);
        Task<Rent> GetByIdAsync(int rentId);
    }
}
