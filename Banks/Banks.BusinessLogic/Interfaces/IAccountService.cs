using Banks.ViewModels.Models;

namespace Banks.BusinessLogic.Interfaces
{
    public interface IAccountService:IBaseService<BaseViewModel,CollectionBaseVM<BaseViewModel>>
    {
        CollectionBaseVM<BaseViewModel> GetClientAccountsByCode(CodeVM model);
        CollectionBaseVM<BaseViewModel> GetAccountsByCurrency(CurrencyVM model);
    }
}
