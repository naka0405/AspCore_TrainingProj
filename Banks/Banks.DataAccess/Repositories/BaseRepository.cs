using Banks.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Banks.DataAccess
{
    /// <summary>       
    /// Provides general methods for work with entities.         
    /// </summary>
    /// <typeparam name = "TEntity" > TEntity is generic parameter for entity.</<typeparam>
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>, IDisposable
        where TEntity : BaseEntity
    {
        protected ApplicationContext appContext;
        protected DbSet<TEntity> dbSet;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="context">Gives the inctance of application context.</param>
        public BaseRepository(ApplicationContext context)
        {
            appContext = context;
            dbSet = context.Set<TEntity>();
        }

        /// <inheritdoc/>
        public virtual void Delete(TEntity entityToDelete)
        {
            dbSet.Remove(entityToDelete);
        }

        /// <inheritdoc/>
        public virtual async Task<TEntity> GetById(int id)
        {
            return await dbSet.FindAsync(id);
        }

        /// <inheritdoc/>
        public virtual async Task Insert(TEntity entity)
        {
            await dbSet.AddAsync(entity);
        }

        /// <inheritdoc/>
        public void Update(TEntity entityToUpdate)
        {
            appContext.Entry(entityToUpdate).State = EntityState.Modified;
        }

        /// <inheritdoc/>
        public async Task SaveChanges()
        {
            await appContext.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await dbSet.AsNoTracking().ToListAsync();
        }

        /// <inheritdoc/>
        public virtual async Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return await dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            appContext.Dispose();
        }
    }
}
