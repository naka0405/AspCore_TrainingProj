using Banks.Entities.Entities;
using Banks.ViewModels.Models;
using System;
using System.Threading.Tasks;

namespace Banks.BusinessLogic.Interfaces
{
    /// <summary>       
    /// An interface whiсh consist base methods to work with entities.
    /// </summary>
    /// <typeparam name="TEntity">Is generic parameter for entity.</typeparam>
    public interface IBaseService<TEntity> : IDisposable
        where TEntity : BaseEntity, new()
    {
        /// <summary>
        /// Get account by Id.
        /// </summary> 
        /// <typeparam name="TView">Is generic type of view model.</typeparam>
        /// <param name="id">Identifier of the entity for searching.</param>
        /// <returns>Instance of view model.</returns>
        Task<TView> GetById<TView>(int id) where TView : BaseViewModel;

        /// <summary>
        /// Delete method.
        /// </summary>
        ///<param name="id">Identifier of the entity to delete.</param>       
        Task Delete(int id);

        /// <summary>
        /// Create method.
        /// </summary>
        /// <typeparam name="TView">Generic type of view model.</typeparam>
        /// <param name="model">View model with parameters.</param>
        /// <returns>Integer number defines Id of new entity.</returns>
        Task<int> Create<TView>(TView model) where TView : BaseViewModel;

        /// <summary>       
        ///Update method.
        /// </summary>
        /// <typeparam name="TView">Generic type of view model.</typeparam>
        /// <param name="model">View model with parameters.</param>        
        Task Update<TView>(TView model) where TView : BaseViewModel;
    }
}
