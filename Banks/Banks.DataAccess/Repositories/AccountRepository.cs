using Microsoft.EntityFrameworkCore;
using Banks.Entities;
using System.Linq;
using System.Collections.Generic;
using System;
using Banks.Entities.Enums;
using Banks.DataAccess.Interfaces;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Banks.DataAccess.Repositories
{
    public class AccountRepository: BaseRepository<Account>, IAccountRepository
    {
        public AccountRepository(ApplicationContext context):base(context)
        { }

        public async Task<IEnumerable<Account>>GetByClientCode(string code)
        {
            return await this.appContext.Accounts.Include(x => x.Client).Where(x => x.Client.Code == code).ToListAsync();
        }

        public async Task<IEnumerable<Account>>GetByCurrency(Currencies currency)
        {
            return await this.appContext.Accounts.Where(x => x.Currency == currency).ToListAsync();
        }

        public override async Task<Account> GetById(int id)
        {
            return await this.appContext.Accounts.Include(x => x.Client).FirstOrDefaultAsync(x => x.Id == id);
        }

        public override async Task<IEnumerable<Account>>GetAll()
        {
            return await this.appContext.Accounts.Include(x => x.Client).ToListAsync();
        }

        public override async Task<IEnumerable<Account>> GetAll(Expression<Func<Account,bool>> predicate)
        {
            return await this.appContext.Accounts.Include(x => x.Client).ThenInclude(x=>x.Bank).ToListAsync();
        }

    }
}
