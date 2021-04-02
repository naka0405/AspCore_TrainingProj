using Banks.Users.ViewModels;
using Banks.ViewModels.ViewModels.Users;
using System.Threading.Tasks;

namespace Banks.BusinessLogic.Interfaces
{
    /// <summary>
    /// An interface that consists of methods to work with User entity.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Logs user into the system.
        /// </summary>
        /// <param name="model">View model with parameters.</param>
        /// <returns>View model with access token.</returns>
        Task<JwtViewModel> LogIn(LoginUserViewModel model);

        /// <summary>
        /// Creates new user.
        /// </summary>
        /// <param name="model">View model with parameters.</param>
        /// <returns>View model with access token.</returns>
        Task<JwtViewModel> Registration(RegistrationUserViewModel model);
    }
}
