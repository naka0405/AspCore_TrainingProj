using Banks.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Banks.DataAccess
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>, IDisposable
        where TEntity : BaseEntity
    {
        protected ApplicationContext appContext;
        protected DbSet<TEntity> dbSet;

        public BaseRepository(ApplicationContext context)
        {
            appContext = context;
            dbSet = context.Set<TEntity>();
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            dbSet.Remove(entityToDelete);
        }

        public virtual async Task<TEntity> GetById(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task Insert(TEntity entity)
        {
            await dbSet.AddAsync(entity);
        }

        public void Update(TEntity entityToUpdate)
        {
            appContext.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public async Task SaveChanges()
        {
            await appContext.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await dbSet.AsNoTracking().ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return await dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public void Dispose()
        {
            appContext.Dispose();
        } 
    }
}
