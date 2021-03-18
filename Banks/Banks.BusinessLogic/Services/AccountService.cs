using AutoMapper;
using Banks.BusinessLogic.Interfaces;
using Banks.DataAccess.Interfaces;
using Banks.Entities;
using Banks.ViewModels.ViewModels.Account;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banks.BusinessLogic.Services
{
    /// <summary>       
    /// service class to relation Dal and Api according to
    /// client requests. Use mapper, entity and viewModels 
    /// </summary>
    public class AccountService:BaseService<Account>, IAccountService        
    {
        private readonly IAccountRepository accountRepo;
        public AccountService(IAccountRepository repository, IMapper mapper):base(repository, mapper)
        {
            accountRepo = repository;            
        }

        /// <summary>       
        /// get accounts using protected GetAll() from baseService and selected by search parameters
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
            return await Task.FromResult(collectionViewModel);
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
           return await Task.FromResult(collectionViewModel);
        }

        /// <summary>       
        /// Update entity from Db getting datas from UI
        /// </summary>
        public async Task Update(UpdateAccountViewModel model)
        {           
            var entity =  this.repository.GetById(model.Id).Result;
            var dataForUpdate = mapper.Map<UpdateAccountViewModel, Account>(model,entity);
            repository.Update(dataForUpdate);
            await repository.SaveChanges();
        }
    }
}
