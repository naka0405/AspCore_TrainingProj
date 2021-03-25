using Banks.ViewModels.Models;

namespace Banks.ViewModels.ViewModels.Account
{
    /// <summary>       
    /// ViewModel to delete some account.        
    /// </summary>
    public class DeleteAccountViewModel:BaseViewModel
    {
        /// <summary>
        /// 
        /// </summary>
       public string Number { get; set; }

        /// <summary>
       /// 
       /// </summary>
       public int BankId { get; set; }
    }
}
