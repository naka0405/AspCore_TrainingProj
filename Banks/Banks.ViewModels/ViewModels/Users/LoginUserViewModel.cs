namespace Banks.ViewModels.ViewModels.Users
{
    /// <summary>
    /// ViewModel consists of login and password of user for authentication.
    /// </summary>
    public class LoginUserViewModel
    {
        /// <summary>
        /// Gets or sets user login.
        /// </summary>
        public string Login { get; set; }  
        
        /// <summary>
        /// Gets or sets user password.
        /// </summary>
        public string Password { get; set; }
    }
}
