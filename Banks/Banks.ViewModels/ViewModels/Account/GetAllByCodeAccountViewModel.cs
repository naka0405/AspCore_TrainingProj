namespace Banks.ViewModels.Models
{
    /// <summary>       
    /// ViewModel to select accounts by clientCode.      
    /// </summary>
    public class GetAllByCodeAccountViewModel
    {
        /// <summary>
        /// Gets or sets id of the bank.
        /// </summary>
        public int BankId { get; set; }

        /// <summary>
        /// Gets or sets identification code of the client.
        /// </summary>
        public string ClientCode { get; set; }
    }
}
