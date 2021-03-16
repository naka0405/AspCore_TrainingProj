using Banks.ViewModels.Models;
using System.Threading.Tasks;

namespace Banks.BusinessLogic.Interfaces
{
    public interface IAccountService:IBaseService<BaseViewModel,CollectionBaseVM<BaseViewModel>>
    {
        Task<CollectionBaseVM<AccountVM>> GetClientAccountsByCode(CodeVM model);
        Task<CollectionBaseVM<AccountVM>> GetAccountsByCurrency(CurrencyVM model);

    }
}
