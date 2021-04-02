using Banks.DataAccess.Interfaces;
using Banks.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Banks.DataAccess.Repositories
{
    /// <summary>       
    /// Contains methods to access Account entity data. 
    /// </summary>
    public class AccountRepository: BaseRepository<Account>, IAccountRepository
    {
        /// <summary>
        /// Creates an instance of AccountRepository.
        /// </summary>
        /// <param name="context">An instance of context.</param>
        public AccountRepository(ApplicationContext context):base(context)
        { }

        ///<inheritdoc/>
        public async Task<IEnumerable<Account>>GetByClientCode(int bankId, string code)
        {           
           return await this.appContext.Accounts
                .Include(x => x.Client)
                .ThenInclude(x => x.Bank)
                .Where(x => x.Client.BankId == bankId && x.Client.Code == code)
                .ToListAsync();            
        }

        ///<inheritdoc/>
        public override async Task<Account> GetById(int id)
        {
            return await this.appContext.Accounts.Include(x => x.Client).ThenInclude(x=>x.Bank).FirstOrDefaultAsync(x => x.Id == id);
        }

        ///<inheritdoc/>
        public override async Task<IEnumerable<Account>>GetAll()
        {
            return await this.appContext.Accounts.Include(x => x.Client).ThenInclude(x => x.Bank).ToListAsync();
        }

        ///<inheritdoc/>
        public override async Task<IEnumerable<Account>> GetAll(Expression<Func<Account,bool>> predicate)
        {
            return await this.appContext.Accounts.Include(x => x.Client).ThenInclude(x=>x.Bank).ToListAsync();
        }

    }
}
