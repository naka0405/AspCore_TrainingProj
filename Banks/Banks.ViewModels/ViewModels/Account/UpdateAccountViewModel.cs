using Banks.ViewModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banks.ViewModels.ViewModels.Account
{
    /// <summary>       
    /// viewModel for set new datas and update
    /// </summary>
    public class UpdateAccountViewModel:BaseViewModel
    {
        public string Number { get; set; }
        public int Currency { get; set; }
    }
}
