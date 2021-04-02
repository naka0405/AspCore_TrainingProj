using System.ComponentModel.DataAnnotations;

namespace Banks.Users.ViewModels
{
    public class RegistrationUserViewModel
    {
        [Required]
        public string Login { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Birth Year")]
        public int Year { get; set; }

        [Required]
        [DataType(DataType.Password)]       
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords don't match!")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        public string PasswordConfirm { get; set; }
    }
}
