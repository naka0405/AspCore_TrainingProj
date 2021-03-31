using Banks.ViewModels.Enums;
using Banks.ViewModels.ViewModels.Extentions;
using System;

namespace Banks.ViewModels.ViewModels
{
    public class BadRequestViewModel
    {
        public string Message { get; set; }      

        public BadRequestViewModel(Exception exeption)
        {
            Message = exeption.Message;
        }

        public BadRequestViewModel(ErrorCodes enumItem)
        {
            Message = enumItem.GetErrorMessage();
        }
    }
}
