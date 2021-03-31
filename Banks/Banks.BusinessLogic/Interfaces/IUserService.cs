using Banks.Users.ViewModels;
using Banks.ViewModels.ViewModels.Users;
using System.Threading.Tasks;

namespace Banks.BusinessLogic.Interfaces
{
    /// <summary>
    /// An interface which consists methods to work with User entity.
    /// </summary>
    public interface IUserService
    {        
        Task<JwtViewModel> LogIn(LoginUserViewModel model);
        Task<JwtViewModel> Create(RegistrationUserViewModel model);
    }
}
