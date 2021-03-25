using AutoMapper;
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
        /// Has repository and mapper injection.
        /// </summary>       
        public AccountService(IAccountRepository repository, IMapper mapper):base(repository, mapper)
        {
            accountRepo = repository;            
        }

        /// <summary>       
        /// Get accounts using search parameter integer code of currency.
        /// </summary>
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

        /// <summary>       
        /// Get all accounts by bankId, clientCode
        /// </summary>
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

        /// <summary>       
        /// Update entity from Db getting datas from UI.
        /// </summary>
        /// <param name="model">Consists new values of entity properties.</param>        
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
