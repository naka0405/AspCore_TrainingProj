using Banks.ViewModels.Enums;
using Banks.ViewModels.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Banks.BusinessLogic.Interfaces
{
    public interface IBaseService<TView> : IDisposable
        where TView : BaseViewModel
    {
        Task<TView> GetById(int id);
        List<TView> GetAll();
        List<TView> GetAll(TView conditions);
        Task<bool> Delete(TView model);
        Task<SaveResults> Save(TView model);
        Task<SaveResults> Update(TView model);
    }
}
