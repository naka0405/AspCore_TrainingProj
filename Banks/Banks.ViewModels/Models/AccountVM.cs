namespace Banks.ViewModels.Models
{
    public class AccountVM:BaseViewModel
    {
        public int BankId { get; set; }
        public string ClientFullName { get; set; }
        public string Code { get; set; }
        public string Account { get; set; }
    }
}
