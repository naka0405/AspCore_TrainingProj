using Banks.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Banks.DataAccess
{
    /// <summary>       
    /// Consists of general crud methods to work with entities.
    /// </summary>
    /// <typeparam name="TEntity">TEntity is generic parameter for entity.</<typeparam>
    public interface IBaseRepository<TEntity> : IDisposable
         where TEntity : BaseEntity
    {
        /// <summary>
        /// Get all records from dataBases table.
        /// </summary>   
        /// <returns>All entities.</returns>
        Task<IEnumerable<TEntity>> GetAll();

        /// <summary>
        /// Get all records from databases table by predicate. 
        /// </summary>  
        /// <param name="predicate">Consists search parameter.</params>
        /// <returns>All entities appropriate to parameter.</returns>
        Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Remove entity.
        /// </summary>  
        /// <param name="item">Consists instance of entity.</params> 
        void Delete(TEntity item);

        /// <summary>
        /// Get entity by id.
        /// </summary>   
        /// <param name="id">Consists id of entity.</params> 
        /// <returns>Entity with sought id.</returns>
        Task<TEntity> GetById(int id);

        /// <summary>
        /// Insert entity to table.
        /// </summary> 
        /// <param name="entity">Consists instance of entity.</params>        
        Task Insert(TEntity entity);

        /// <summary>
        /// Update entity in database.
        /// </summary>
        /// <param name="entityToUpdate">Consists instance of entity.</params>
        void Update(TEntity entityToUpdate);

        /// <summary>
        /// Save changes in this context to the database.
        /// </summary>       
        Task SaveChanges();
    }
}
