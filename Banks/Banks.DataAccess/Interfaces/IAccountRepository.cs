using Banks.Entities;
using Banks.Entities.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Banks.DataAccess.Interfaces
{
    public interface IAccountRepository:IBaseRepository<Account>
    {
        Task<IEnumerable<Account>> GetByClientCode(int bankId, string code);
        Task<IEnumerable<Account>> GetByCurrency(int bankId, Currencies currency);
    }
}
