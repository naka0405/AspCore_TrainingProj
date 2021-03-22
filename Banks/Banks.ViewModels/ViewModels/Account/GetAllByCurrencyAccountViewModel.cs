using Banks.Entities.Enums;

namespace Banks.ViewModels.Models
{
    /// <summary>       
    /// ViewModel for select accounts by currency.      
    /// </summary>
    public class GetAllByCurrencyAccountViewModel
    {
        /// <summary>
        /// Gets or sets id of Bank in database.
        /// </summary>
        public int BankId { get; set; }
        /// <summary>
        /// Gets or sets kind of currency for search.
        /// </summary>
        public Currencies Currency { get; set; }
    }
}
