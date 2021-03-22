using Banks.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Banks.DataAccess.Interfaces
{
    /// <summary>       
    /// Add specific capabilities to manipulate accountEntity.
    /// </summary>
    public interface IAccountRepository:IBaseRepository<Account>
    {
        /// <summary>
        /// Get all accounts from db by specific clientCode.
        /// </summary>      
        Task<IEnumerable<Account>> GetByClientCode(int bankId, string code);       
    }
}
