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
    /// Provides general methods for work with entities from db         
    /// </summary>
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

        /// <summary>       
        /// Remove entity       
        /// </summary>
        public virtual void Delete(TEntity entityToDelete)
        {
            dbSet.Remove(entityToDelete);
        }

        /// <summary>       
        /// Get entity by id       
        /// </summary>
        public virtual async Task<TEntity> GetById(int id)
        {
            return await dbSet.FindAsync(id);
        }

        /// <summary>       
        /// Insert entity to table        
        /// </summary>
        public virtual async Task Insert(TEntity entity)
        {
           var entryEntity=await dbSet.AddAsync(entity);          
        }

        /// <summary>       
        /// Update entity in Db        
        /// </summary>
        public void Update(TEntity entityToUpdate)
        {
            appContext.Entry(entityToUpdate).State = EntityState.Modified;
        }

        /// <summary>       
        /// Save changes in this context to the Db
        /// </summary>
        public async Task SaveChanges()
        {
           await appContext.SaveChangesAsync();
        }

        /// <summary>       
        /// Get all records from Db table       
        /// </summary>
        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await dbSet.AsNoTracking().ToListAsync();
        }

        /// <summary>       
        /// Get all records from Db table by predicate        
        /// </summary>
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
