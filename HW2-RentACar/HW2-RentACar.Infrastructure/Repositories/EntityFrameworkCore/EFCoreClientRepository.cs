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
    public class EFCoreClientRepository : EFCoreRepository<Client>, IEFCoreClientRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; } 
        public EFCoreClientRepository(AppDbContext context) : base(context)
        {
        }
    }
}
