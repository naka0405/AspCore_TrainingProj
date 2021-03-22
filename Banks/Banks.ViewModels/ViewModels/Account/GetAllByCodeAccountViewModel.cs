namespace Banks.ViewModels.Models
{
    /// <summary>       
    /// ViewModel for select accounts by clientCode.      
    /// </summary>
    public class GetAllByCodeAccountViewModel
    {
        /// <summary>
        /// Gets or sets id of the bank in Dbtable.
        /// </summary>
        public int BankId { get; set; }
        /// <summary>
        /// Gets or sets identification code of the client in Dbtable.
        /// </summary>
        public string ClientCode { get; set; }
    }
}
