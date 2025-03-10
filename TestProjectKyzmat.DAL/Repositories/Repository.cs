using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestProjectKyzmat.Core.Entities.Common.Interfaces;

namespace TestProjectKyzmat.DAL.Repositories
{
    public class Repository<TEntity>(ApplicationDbContext context) : IRepository<TEntity> where TEntity : class
    {
        public async Task AddAsync(TEntity entity) => await context.Set<TEntity>().AddAsync(entity);
        public IQueryable<TEntity> GetAll() => context.Set<TEntity>();
        public async Task<TEntity?> GetByIdAsync(int id) => await context.Set<TEntity>().FindAsync(id);
        public IQueryable<TEntity> GetRange(Expression<Func<TEntity, bool>> predicate) => context.Set<TEntity>().Where(predicate);
        public async Task RemoveByIdAsync(int id)
        {
            TEntity? entity = await GetByIdAsync(id);
            if (entity != null)
                context.Set<TEntity>().Remove(entity);
        }
        public void RemoveRange(IEnumerable<TEntity> entities) => context.Set<TEntity>().RemoveRange(entities);
        public void Update(TEntity entity) => context.Set<TEntity>().Update(entity);
        public async Task<int> SaveChangesAsync() => await context.SaveChangesAsync();
    }
}
