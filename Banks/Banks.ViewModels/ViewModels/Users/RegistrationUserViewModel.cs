using System.ComponentModel.DataAnnotations;

namespace Banks.Users.ViewModels
{
    /// <summary>
    /// View model consists of properties to registration new user.
    /// </summary>
    public class RegistrationUserViewModel
    {
        /// <summary>
        /// Defines login of the user.
        /// </summary>
        [Required]
        public string Login { get; set; }

        /// <summary>
        /// Defines email of the user.
        /// </summary>
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        /// <summary>
        /// Defines the birth year of the user.
        /// </summary>
        [Required]
        [Display(Name = "Birth Year")]
        public int Year { get; set; }

        /// <summary>
        /// Defines the password.
        /// </summary>
        [Required]
        [DataType(DataType.Password)]       
        public string Password { get; set; }

        /// <summary>
        /// Defines the password matching.
        /// </summary>
        [Required]
        [Compare("Password", ErrorMessage = "Passwords don't match!")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        public string PasswordConfirm { get; set; }
    }
}
