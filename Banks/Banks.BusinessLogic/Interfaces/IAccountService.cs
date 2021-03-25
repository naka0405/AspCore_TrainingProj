using Banks.Entities;
using Banks.ViewModels.ViewModels.Account;
using System.Threading.Tasks;

namespace Banks.BusinessLogic.Interfaces
{
    /// <summary>       
    /// An interface which contains methods to work with aacount entity.
    /// </summary>
    public interface IAccountService:IBaseService<Account>
    {   
        /// <summary>
        /// Get async accounts with specified client code.
        /// </summary>      
        Task<GetAllAccountViewModel> GetClientAccountsByCode(int bankId, string clientCode);

        /// <summary>
        /// Get async accounts with specified currencyCode.
        /// </summary>       
        Task<GetAllAccountViewModel> GetByCurrency(int bankId, int currencyCode);
    }
}
