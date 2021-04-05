using Banks.ViewModels.Models;

namespace Banks.ViewModels.ViewModels.Account
{
    /// <summary>       
    /// ViewModel to return account by id.      
    /// </summary>
    public class GetByIdAccountViewModel:BaseViewModel
    {
        /// <summary>
        /// Gets or sets number of account.
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Gets or sets client's full name, whish consist of firstName and lastName.
        /// </summary>
        public string ClientFullName { get; set; }

        /// <summary>
        /// Gets or sets client's identification code.
        /// </summary>
        public string ClientCode { get; set; }

        /// <summary>
        /// Gets or sets kind of currency in string format for preview on UI.
        /// </summary>
        public string Currency { get; set; }
    }
}
