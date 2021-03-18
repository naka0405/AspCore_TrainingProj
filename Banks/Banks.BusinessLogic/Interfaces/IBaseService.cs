using Banks.Entities.Entities;
using Banks.ViewModels.Models;
using System;
using System.Threading.Tasks;

namespace Banks.BusinessLogic.Interfaces
{
    /// <summary>       
    /// Consist general methods to manipulate entities
    /// </summary>
    public interface IBaseService<TEntity> : IDisposable
        where TEntity : BaseEntity, new()        
    {
        Task<TView> GetById<TView>(int id) where TView:BaseViewModel;
        Task Delete<TView>(TView model) where TView : BaseViewModel;
        Task<int> Create<TView>(TView model) where TView : BaseViewModel;
        Task Update<TView>(TView model) where TView : BaseViewModel;
    }
}
