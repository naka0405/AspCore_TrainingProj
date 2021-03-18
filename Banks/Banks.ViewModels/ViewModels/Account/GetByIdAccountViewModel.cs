using Banks.ViewModels.Models;

namespace Banks.ViewModels.ViewModels.Account
{
    /// <summary>       
    /// viewModel for return account by id      
    /// </summary>
    public class GetByIdAccountViewModel:BaseViewModel
    {
        public int Number { get; set; }
        public string ClientFullName { get; set; }
        public string ClientCode { get; set; }
        public string Currency { get; set; }
    }
}
