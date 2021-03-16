using AutoMapper;
using Banks.BusinessLogic.Interfaces;
using Banks.DataAccess.Interfaces;
using Banks.Entities;
using Banks.ViewModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banks.BusinessLogic.Services
{
    public class AccountService:BaseService<Account, BaseViewModel, CollectionBaseVM<BaseViewModel>>, IAccountService        
    {
        private readonly IAccountRepository accountRepo;
        public AccountService(IAccountRepository repository, IMapper mapper):base(repository, mapper)
        {
            accountRepo = repository;            
        }

        public async Task<CollectionBaseVM<AccountVM>> GetAccountsByCurrency(CurrencyVM model)
        {
            var accounts = (await Task.FromResult( accountRepo.GetByCurrency(model.BankId, model.Currency)).Result).ToList();
            if(accounts.Count==0)
            {
                throw new ArgumentException("Accounts were't found");
            }
            var collectionModel = new CollectionBaseVM<AccountVM>(this.mapper.Map<List<AccountVM>>(accounts));
            return await Task.FromResult(collectionModel);
        }

        public async Task<CollectionBaseVM<AccountVM>> GetClientAccountsByCode(CodeVM model)
        {
            var accounts = (await Task.FromResult(accountRepo.GetByClientCode(model.BankId, model.ClientCode)).Result).ToList();
            if (accounts.Count == 0)
            {
                throw new ArgumentException("Accounts were't found");
            }
            var collectionModel = new CollectionBaseVM<AccountVM>(this.mapper.Map<List<AccountVM>>(accounts));
            return await Task.FromResult(collectionModel);
        }
    }
}
