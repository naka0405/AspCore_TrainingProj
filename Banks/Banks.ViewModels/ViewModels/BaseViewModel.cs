using System;
using System.Collections.Generic;
using System.Text;

namespace Banks.ViewModels.Models
{
    /// <summary>       
    /// viewModel for inheritance with general property      
    /// </summary>
    public class BaseViewModel
    {
        public int Id { get; set; }
        
        public BaseViewModel(int id=default)
        {
            this.Id = id;
        }

        public BaseViewModel()
        {

        }
    }
}
