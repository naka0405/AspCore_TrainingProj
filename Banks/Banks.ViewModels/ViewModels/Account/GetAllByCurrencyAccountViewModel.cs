using Banks.Entities.Enums;

namespace Banks.ViewModels.Models
{
    /// <summary>       
    /// ViewModel to select accounts by currency.      
    /// </summary>
    public class GetAllByCurrencyAccountViewModel
    {
        /// <summary>
        /// Gets or sets id of the Bank.
        /// </summary>
        public int BankId { get; set; }

        /// <summary>
        /// Gets or sets kind of currency for search.
        /// </summary>
        public Currencies Currency { get; set; }
    }
}
