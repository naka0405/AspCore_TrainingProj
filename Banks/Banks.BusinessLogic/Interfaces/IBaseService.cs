using Banks.Entities.Entities;
using Banks.ViewModels.Models;
using System;
using System.Threading.Tasks;

namespace Banks.BusinessLogic.Interfaces
{
    /// <summary>       
    /// Consist general methods to manipulate entities.
    /// </summary>
    public interface IBaseService<TEntity> : IDisposable
        where TEntity : BaseEntity, new()        
    {
        /// <summary>
        /// Get account by Id or exepption if not found.
        /// </summary>        
        Task<TView> GetById<TView>(int id) where TView:BaseViewModel;

        /// <summary>
        /// Delete account.
        /// </summary>       
        Task Delete(int id) ;
        /// <summary>
        /// Map viewModel from api to entity and insert it in the db.
        /// </summary>        
        Task<int> Create<TView>(TView model) where TView : BaseViewModel;

        /// <summary>       
        /// Get entity for update from db, try update using map viewmodel on it.
        /// </summary>
        Task Update<TView>(TView model) where TView : BaseViewModel;
    }
}
