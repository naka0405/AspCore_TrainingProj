using Banks.ViewModels.Models;
using System;
using System.Threading.Tasks;

namespace Banks.BusinessLogic.Interfaces
{
    public interface IBaseService<TView,C> : IDisposable
        where TView : BaseViewModel, new()
        where C:CollectionBaseVM<TView>, new()
    {
        Task<TView> GetById(int id);
        C GetAll();
        C GetAll(TView conditions);
        Task Delete(TView model);
        Task<int> Create(TView model);
        Task Update(TView model);
    }
}
