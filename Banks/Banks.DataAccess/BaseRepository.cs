using Banks.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banks.DataAccess
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity:BaseEntity
    {
        internal ApplicationContext appContext;
        internal DbSet<TEntity> dbSet;

        public BaseRepository(ApplicationContext context)
        {
            appContext = context;
            dbSet = context.Set<TEntity>();
        }
        public BaseRepository()
        {

        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (entityToDelete == null)
            {
                throw new ArgumentException("Cannot add a null entity.");
            }
            if (appContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public virtual async Task<TEntity> GetById(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public void Update(TEntity entityToUpdate)
        {
            appContext.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public async Task SaveChanges()
        {
            await appContext.SaveChangesAsync();
        }

        public IEnumerable<TEntity> Get()
        {
            return dbSet.AsNoTracking();
        }

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return dbSet.AsNoTracking().Where(predicate);
        }
    }
}
