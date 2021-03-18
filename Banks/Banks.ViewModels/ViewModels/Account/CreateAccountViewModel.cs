using Banks.Entities.Enums;
using Banks.ViewModels.Models;

namespace Banks.ViewModels.ViewModels.Account
{
    /// <summary>       
    /// viewModdel for create new account        
    /// </summary>
    public class CreateAccountViewModel:BaseViewModel
    {
        public int BankId { get; set; }
        public int ClientId { get;set; }
        public int CurrencyCode { get; set; }
        public int Number { get; set; }
        public string Account => ((Currencies)CurrencyCode).ToString() + Number.ToString();
        public CreateAccountViewModel(int newId)
        {
            this.Id = newId
;        }

        public CreateAccountViewModel()
        {
            
        }
    }
}
