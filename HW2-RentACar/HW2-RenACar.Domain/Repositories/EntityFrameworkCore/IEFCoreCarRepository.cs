using HW2_RenACar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2_RenACar.Domain.Repositories.EntityFrameworkCore
{
    public interface IEFCoreCarRepository : IEFCoreRepository<Car>
    {
    }
}
