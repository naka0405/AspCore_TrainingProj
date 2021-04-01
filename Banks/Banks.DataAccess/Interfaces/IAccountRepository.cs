using Banks.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Banks.DataAccess.Interfaces
{
    /// <summary>       
    /// Contains methods to access Account specific data.
    /// </summary>
    public interface IAccountRepository:IBaseRepository<Account>
    {
        /// <summary>
        /// Get all accounts from db by specific clientCode.
        /// </summary>   
        /// <param name="bankId">The Id of bank.</param>
        /// <param name="code">The string with identification code of client.</param>
        /// <returns>All accounts correspondents with parameters.</returns>
        Task<IEnumerable<Account>> GetByClientCode(int bankId, string code);       
    }
}
