using Banks.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banks.ViewModels.Models
{
    /// <summary>       
    /// viewModel for select accounts by currency      
    /// </summary>
    public class GetAllByCurrencyAccountViewModel
    {
        public int BankId { get; set; }
        public Currencies Currency { get; set; }
    }
}
