using Banks.Entities.Entities;
using Banks.ViewModels.Models;
using System;
using System.Threading.Tasks;

namespace Banks.BusinessLogic.Interfaces
{
    /// <summary>       
    /// An interface whish consist base functionality to work with entities.
    /// </summary>
    public interface IBaseService<TEntity> : IDisposable
        where TEntity : BaseEntity, new()        
    {
        /// <summary>
        /// Get account by Id.
        /// </summary>        
        Task<TView> GetById<TView>(int id) where TView:BaseViewModel;

        /// <summary>
        /// Delete method.
        /// </summary>       
        Task Delete(int id) ;
        /// <summary>
        /// Create method.
        /// </summary>        
        Task<int> Create<TView>(TView model) where TView : BaseViewModel;

        /// <summary>       
        ///Update method.
        /// </summary>
        Task Update<TView>(TView model) where TView : BaseViewModel;
    }
}
