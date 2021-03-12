using Banks.Entities;
using Banks.Entities.Enums;
using System.Collections.Generic;

namespace Banks.DataAccess.Interfaces
{
    public interface IAccountRepository
    {
        IEnumerable<Account> GetByClientCode(string code);
        IEnumerable<Account> GetByCurrency(Currencies currency);
    }
}
