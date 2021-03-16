using Banks.Entities;
using Banks.Entities.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Banks.DataAccess.Interfaces
{
    public interface IAccountRepository:IBaseRepository<Account>
    {
        Task<IEnumerable<Account>> GetByClientCode(string code);
        Task<IEnumerable<Account>> GetByCurrency(Currencies currency);
    }
}
