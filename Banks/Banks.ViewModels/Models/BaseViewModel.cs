using System;
using System.Collections.Generic;
using System.Text;

namespace Banks.ViewModels.Models
{
    public class BaseViewModel
    {
        public int Id { get; set; }
        public BaseViewModel(int id=default)
        {
            this.Id = id;
        }
    }
}
