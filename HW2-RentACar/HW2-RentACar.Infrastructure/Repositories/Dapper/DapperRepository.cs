using HW2_RenACar.Domain.Repositories;
using HW2_RenACar.Domain.Repositories.Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HW2_RentACar.Infrastructure.Repositories.Dapper
{
    public class DapperRepository: IDapperRepository
    {
        protected readonly DbContext Context;

        public DapperRepository(DbContext context)
        {
            this.Context = context;
        }

        
    }
}
