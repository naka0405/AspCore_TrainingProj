using Banks.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Banks.DataAccess
{
    /// <summary>       
    /// Consist general crud methods to work with entities in Db.
    /// </summary>
    public interface IBaseRepository<TEntity> : IDisposable
         where TEntity : BaseEntity
    {
        /// <summary>
        /// Get all records from Db table.
        /// </summary>       
        Task<IEnumerable<TEntity>> GetAll();
        /// <summary>
        /// Get all records from Db table by predicate. 
        /// </summary>      
        Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate);
        /// <summary>
        /// Remove entity.
        /// </summary>        
        void Delete(TEntity item);
        /// <summary>
        /// Get entity by id.
        /// </summary>       
        Task<TEntity> GetById(int id);
        /// <summary>
        /// Insert entity to table.
        /// </summary>        
        Task Insert(TEntity entity);
        /// <summary>
        /// Update entity in Db.
        /// </summary>       
        void Update(TEntity entityToUpdate);
        /// <summary>
        /// Save changes in this context to the Db.
        /// </summary>       
        Task SaveChanges();
    }
}
