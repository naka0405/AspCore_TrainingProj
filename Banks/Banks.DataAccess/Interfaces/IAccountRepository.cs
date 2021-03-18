using Banks.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Banks.DataAccess.Interfaces
{
    /// <summary>       
    /// add specific capabilities to manipulate accountEntity 
    /// </summary>
    public interface IAccountRepository:IBaseRepository<Account>
    {
        Task<IEnumerable<Account>> GetByClientCode(int bankId, string code);       
    }
}
