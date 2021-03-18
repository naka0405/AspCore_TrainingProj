namespace Banks.ViewModels.Models
{
    /// <summary>       
    /// viewModel for select accounts by clientCode      
    /// </summary>
    public class GetAllByCodeAccountViewModel
    {
        public int BankId { get; set; }
        public string ClientCode { get; set; }
    }
}
