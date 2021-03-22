using Banks.Entities.Enums;
using Banks.ViewModels.Models;

namespace Banks.ViewModels.ViewModels.Account
{
    /// <summary>       
    /// ViewModdel for create new account.        
    /// </summary>
    public class CreateAccountViewModel:BaseViewModel
    {
        /// <summary>
        /// Gets or sets id of the bank in Dbtable.
        /// </summary>
        public int BankId { get; set; }
        /// <summary>
        /// Gets or sets id of the client in Dbtable.
        /// </summary>
        public int ClientId { get;set; }
        /// <summary>
        /// Gets or sets integer code of currency kind, which matches to enum.
        /// </summary>
        public int CurrencyCode { get; set; }
        /// <summary>
        /// Gets or sets integer part for number of account.
        /// </summary>
        public int Number { get; set; }
        /// <summary>
        /// Gets full string number contains literal link for currency
        /// and integer part.
        /// </summary>
        public string Account => ((Currencies)CurrencyCode).ToString() + Number.ToString();      
    }
}
