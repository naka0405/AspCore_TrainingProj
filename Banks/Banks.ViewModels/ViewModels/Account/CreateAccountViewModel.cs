using Banks.Entities.Enums;
using Banks.ViewModels.Models;

namespace Banks.ViewModels.ViewModels.Account
{
    /// <summary>       
    /// ViewModel to create a new account.        
    /// </summary>
    public class CreateAccountViewModel:BaseViewModel
    {
        /// <summary>
        /// Gets or sets id of the bank.
        /// </summary>
        public int BankId { get; set; }

        /// <summary>
        /// Gets or sets id of the client.
        /// </summary>
        public int ClientId { get;set; }

        /// <summary>
        /// Gets or sets currency.
        /// </summary>
        public Currencies Currency { get; set; }

        /// <summary>
        /// Gets or sets integer part for number of account.
        /// </summary>
        public int Number { get; set; }
    }
}
