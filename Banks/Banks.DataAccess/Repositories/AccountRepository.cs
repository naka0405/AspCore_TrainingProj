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
    /// implement baseRepository and consist another convinient method for work with accountEntity in Db 
    /// </summary>
    public class AccountRepository: BaseRepository<Account>, IAccountRepository
    {
        public AccountRepository(ApplicationContext context):base(context)
        { }

        /// <summary>       
        /// Get all accounts from db by specific bankId, clientCode        
        /// </summary>
        public async Task<IEnumerable<Account>>GetByClientCode(int bankId, string code)
        {           
           return await this.appContext.Accounts
                .Include(x => x.Client)
                .ThenInclude(x => x.Bank)
                .Where(x => x.Client.BankId == bankId && x.Client.Code == code)
                .ToListAsync();            
        }

        /// <summary>       
        /// Get account from db by Id       
        /// </summary>
        public override async Task<Account> GetById(int id)
        {
            return await this.appContext.Accounts.Include(x => x.Client).ThenInclude(x=>x.Bank).FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <summary>       
        /// Get all accounts from db including Client and Bank entity for everyone        
        /// </summary>
        public override async Task<IEnumerable<Account>>GetAll()
        {
            return await this.appContext.Accounts.Include(x => x.Client).ThenInclude(x => x.Bank).ToListAsync();
        }

        /// <summary>       
        /// Get all accounts from db by specific predicate        
        /// </summary>
        public override async Task<IEnumerable<Account>> GetAll(Expression<Func<Account,bool>> predicate)
        {
            return await this.appContext.Accounts.Include(x => x.Client).ThenInclude(x=>x.Bank).ToListAsync();
        }

    }
}
