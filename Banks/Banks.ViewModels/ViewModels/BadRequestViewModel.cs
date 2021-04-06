using Banks.ViewModels.Enums;
using Banks.ViewModels.ViewModels.Extentions;
using System;

namespace Banks.ViewModels.ViewModels
{
    /// <summary>
    /// View model for return to the UI.
    /// </summary>
    public class BadRequestViewModel
    {
        /// <summary>
        /// Defines string with error message.
        /// </summary>
        public string Message { get; set; }


        /// <summary>
        /// Creates an instance of a BadRequestViewModel.
        /// </summary>
        /// <param name="exeption">Instance of the Exeption.</param>
        public BadRequestViewModel(Exception exeption)
        {
            Message = exeption.Message;
        }        
    }
}
