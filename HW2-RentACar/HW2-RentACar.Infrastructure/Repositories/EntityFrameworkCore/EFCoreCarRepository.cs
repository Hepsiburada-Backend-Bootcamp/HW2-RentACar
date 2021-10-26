using HW2_RenACar.Domain.Entities;
using HW2_RenACar.Domain.Repositories.EntityFrameworkCore;
using HW2_RentACar.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2_RentACar.Infrastructure.Repositories.EntityFrameworkCore
{
    public class EFCoreCarRepository : EFCoreRepository<Car>, IEFCoreCarRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }
        public EFCoreCarRepository(AppDbContext context) : base(context)
        {
        }

    }
}
