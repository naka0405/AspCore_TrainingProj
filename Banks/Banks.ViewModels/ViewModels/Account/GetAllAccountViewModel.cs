using Banks.Entities.Enums;
using Banks.ViewModels.Models;

namespace Banks.ViewModels.ViewModels.Account
{
    /// <summary>       
    /// child viewModel which implements generic viewModel with generic collection        
    /// </summary>
    public class GetAllAccountViewModel:CollectionBaseViewModel<AccountGetAllAccountViewModelItem>
    {       
       
    }

    public class AccountGetAllAccountViewModelItem
    {
        public int BankId { get; set; }
        public string ClientFullName { get; set; }
        public string Code { get; set; }
        public string Account { get; set; }
        public Currencies Currency { get; set; }
    }
}
