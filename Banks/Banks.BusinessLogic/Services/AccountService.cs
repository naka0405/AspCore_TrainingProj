﻿using AutoMapper;
using Banks.BusinessLogic.Interfaces;
using Banks.DataAccess.Interfaces;
using Banks.Entities;
using Banks.ViewModels.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banks.BusinessLogic.Services
{
    /// <summary>       
    /// Service class to relation Dal and Api according to
    /// client requests. Use mapper, entity and viewModels. 
    /// </summary>
    public class AccountService:BaseService<Account>, IAccountService        
    {
        private readonly IAccountRepository accountRepo;

        /// <summary>
        /// Creates an instance of AccountService.
        /// </summary> 
        /// <param name="mapper">Defines instance of Mapper.</param>
        /// <param name="repository">Defines instance of account repository.</param>
        public AccountService(IAccountRepository repository, IMapper mapper):base(repository, mapper)
        {
            accountRepo = repository;            
        }

        ///<inheritdoc/>
        public async Task<GetAllAccountViewModel> GetByCurrency(int bankId, int currencyCode)
        {
            var selectedItems=(await this.GetAll<AccountGetAllAccountViewModelItem>()).Where(x => x.BankId == bankId && (int)x.Currency == currencyCode)
                .ToList();
            var collectionViewModel = new GetAllAccountViewModel();
            if (selectedItems.Count!=0)
            {
                collectionViewModel.Items = selectedItems;               
            }            
            return collectionViewModel;
        }

        ///<inheritdoc/>
        public async Task<GetAllAccountViewModel> GetClientAccountsByCode(int bankId, string clientCode)
        {
            var accounts = (await accountRepo.GetByClientCode(bankId, clientCode)).ToList();
            var collectionViewModel = new GetAllAccountViewModel();
            if (accounts.Count != 0)
            {  
                collectionViewModel.Items = this.mapper.Map<List<AccountGetAllAccountViewModelItem>>(accounts);
            }           
           return collectionViewModel;
        }

        ///<inheritdoc/>        
        public async Task Update(UpdateAccountViewModel model)
        {           
            var entity = await this.repository.GetById(model.Id);
            if (entity == null)
            {
                throw new ArgumentException("Such entity not found!");
            }
            var dataForUpdate = mapper.Map<UpdateAccountViewModel, Account>(model,entity);
            repository.Update(dataForUpdate);
            await repository.SaveChanges();
        }
    }
}
