using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectKyzmat.Core.Entities.Common.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity);
        IQueryable<TEntity> GetAll();
        Task<TEntity?> GetByIdAsync(int id);
        IQueryable<TEntity> GetRange(Expression<Func<TEntity, bool>> predicate);
        Task RemoveByIdAsync(int id);
        void RemoveRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        Task<int> SaveChangesAsync();
    }
}
