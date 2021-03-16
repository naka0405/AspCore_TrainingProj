using Banks.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banks.ViewModels.Models
{
    public class CurrencyVM
    {
        public int BankId { get; set; }
        public Currencies Currency { get; set; }
    }
}
