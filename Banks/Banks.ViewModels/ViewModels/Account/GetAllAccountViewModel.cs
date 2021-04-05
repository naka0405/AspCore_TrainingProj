using Banks.ViewModels.Enums;
using Banks.ViewModels.Models;

namespace Banks.ViewModels.ViewModels.Account
{
    /// <summary>       
    /// View model to get a collection .        
    /// </summary>
    public class GetAllAccountViewModel:CollectionBaseViewModel<AccountGetAllAccountViewModelItem>
    {       
       
    }

    /// <summary>
    /// ViewModel used for get all accounts.
    /// </summary>
    public class AccountGetAllAccountViewModelItem:BaseViewModel
    {
        /// <summary>
        /// Gets or sets id of the bank.
        /// </summary>
        public int BankId { get; set; }

        /// <summary>
        /// Gets or sets full name of the client as union first name and last name.
        /// </summary>
        public string ClientFullName { get; set; }

        /// <summary>
        /// Gets or sets identification client code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets string number of account.
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// Gets or sets kind of currency from enum.
        /// </summary>
        public Currencies Currency { get; set; }
    }
}
