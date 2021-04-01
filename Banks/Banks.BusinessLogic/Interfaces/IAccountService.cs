using Banks.Entities;
using Banks.ViewModels.ViewModels.Account;
using System.Threading.Tasks;

namespace Banks.BusinessLogic.Interfaces
{
    /// <summary>       
    /// An interface which contains methods to work with account entity.
    /// </summary>
    public interface IAccountService:IBaseService<Account>
    {   
        /// <summary>
        /// Get async accounts with specified client code.
        /// </summary> 
        /// <param name="bankId">Defines id of bank for searching.</param>
        /// <param name="clientCode">Defines identification code of client.</param>
        /// <returns>View model with collection.</returns>
        Task<GetAllAccountViewModel> GetClientAccountsByCode(int bankId, string clientCode);

        /// <summary>
        /// Get async accounts with specified currencyCode.
        /// </summary>
        /// <param name="bankId">Defines id of bank for searching.</param>
        /// <param name="currencyCode">Defines integer number matches to code of currency.</param>
        /// <returns>View model with collection.</returns> 
        Task<GetAllAccountViewModel> GetByCurrency(int bankId, int currencyCode);
    }
}
