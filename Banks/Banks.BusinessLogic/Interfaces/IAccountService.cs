using Banks.Entities;
using Banks.ViewModels.Models;
using Banks.ViewModels.ViewModels.Account;
using System.Threading.Tasks;

namespace Banks.BusinessLogic.Interfaces
{
    /// <summary>       
    /// add for Account some specific methods
    /// </summary>
    public interface IAccountService:IBaseService<Account>
    {        
        Task<GetAllAccountViewModel> GetClientAccountsByCode(int bankID, string clientCode);
        Task<GetAllAccountViewModel> GetByCurrency(int bankId, int currencyCode);


    }
}
