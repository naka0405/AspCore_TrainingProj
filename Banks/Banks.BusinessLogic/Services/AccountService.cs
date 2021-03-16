using AutoMapper;
using Banks.BusinessLogic.Interfaces;
using Banks.DataAccess.Interfaces;
using Banks.DataAccess.Repositories;
using Banks.Entities;
using Banks.ViewModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banks.BusinessLogic.Services
{
    public class AccountService:BaseService<Account, BaseViewModel, CollectionBaseVM<BaseViewModel>>, IAccountService        
    {
        private readonly IAccountRepository accountRepo;
        public AccountService(IAccountRepository repository, IMapper mapper):base(repository, mapper)
        {
            accountRepo = repository;
        }

        public CollectionBaseVM<BaseViewModel> GetAccountsByCurrency(CurrencyVM model)
        {
            throw new NotImplementedException();
        }

        public CollectionBaseVM<BaseViewModel> GetClientAccountsByCode(CodeVM model)
        {
            throw new NotImplementedException();
        }
    }
}
