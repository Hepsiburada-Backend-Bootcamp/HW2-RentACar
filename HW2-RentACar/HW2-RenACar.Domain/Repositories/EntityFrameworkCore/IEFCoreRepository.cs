using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HW2_RenACar.Domain.Repositories.EntityFrameworkCore
{
    public interface IEFCoreRepository<TEntity> where TEntity:class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate);
        Task AddAsync(TEntity entity);
        void Remove(TEntity entity);
        TEntity Update(TEntity entity);
    }
}
