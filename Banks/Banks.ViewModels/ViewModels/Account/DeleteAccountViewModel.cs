using Banks.ViewModels.Models;

namespace Banks.ViewModels.ViewModels.Account
{
    /// <summary>       
    /// viewModel to delete some account        
    /// </summary>
    public class DeleteAccountViewModel:BaseViewModel
    {
       public string Number { get; set; }
       public int BankId { get; set; }
    }
}
