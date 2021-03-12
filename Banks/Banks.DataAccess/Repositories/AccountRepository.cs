using Microsoft.EntityFrameworkCore;
using Banks.Entities;
using System.Linq;
using System.Collections.Generic;
using System;
using Banks.Entities.Enums;
using Banks.DataAccess.Interfaces;

namespace Banks.DataAccess.Repositories
{
    public class AccountRepository:BaseRepository<Account>, IAccountRepository
    {
        public AccountRepository(ApplicationContext context):base(context)
        { }

        public IEnumerable<Account>GetByClientCode(string code)
        {
            return this.appContext.Accounts.Include(x => x.Client).Where(x => x.Client.Code == code);
        }

        public IEnumerable<Account>GetByCurrency(Currencies currency)
        {
            return this.appContext.Accounts.Where(x => x.Currency == currency);
        }

        public new Account GetById(int id)
        {
            return this.appContext.Accounts.Include(x => x.Client).FirstOrDefault(x => x.Id == id);
        }

        public new IEnumerable<Account>GetAll()
        {
            return this.appContext.Accounts.Include(x => x.Client);
        }

        public new IEnumerable<Account> GetAll(Func<Account,bool> predicate)
        {
            return this.appContext.Accounts.Include(x => x.Client).ThenInclude(x=>x.Bank);
        }

    }
}
