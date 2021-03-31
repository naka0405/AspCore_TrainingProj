using AutoMapper;
using Banks.BusinessLogic.Interfaces;
using Banks.Entities.Entities;
using Banks.Users.ViewModels;
using Banks.ViewModels.ViewModels.Users;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace Banks.BusinessLogic.Services
{
    /// <summary>
    /// Service to work with userManager for manage UserEntity.
    /// </summary>
    public class UserService : IUserService
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IMapper mapper;
        private readonly IAuthJwtManager authJwtManager;

        public UserService(UserManager<User> userManager, IAuthJwtManager manager, IMapper mapper, SignInManager<User> signInManager)//UserManager<User> manager, SignInManager<User> signInManager
        {
            this.userManager = userManager;
            this.mapper = mapper;
            this.signInManager = signInManager;
            this.authJwtManager = manager;
        }

        /// <summary>
        /// Consists authentication functionality-gets user, check passwords and create/add new access token.
        /// </summary>      
        /// <param name="model">Consists login and password of user.</param>
        /// <returns>ViewModel with jwt token.</returns>
        public async Task<JwtViewModel> LogIn(LoginUserViewModel model)
        {
            var user = await userManager.FindByNameAsync(model.Login);
            if (user != null)
            {
                var result = await signInManager.CheckPasswordSignInAsync(user, model.Password, false);
                if (result.Succeeded)
                {
                    // create JWT-token
                    return new JwtViewModel
                    {                       
                        Token = authJwtManager.GenerateToken(user)
                    };
                }
                else
                {
                    throw new ArgumentException("Password doesn't match!");
                }
            }
            throw new ArgumentException("User not found!"); ;
        }
      
        /// <summary>
        /// Create new user and access token at registration process.
        /// </summary> 
        /// <param name="model">Consists login, password, year of birth and confirm password.</param>
        public async Task<JwtViewModel> Create(RegistrationUserViewModel model)
        {
            var user = new User { Email = model.Email, UserName = model.Login, Year = model.Year };
            var result = await userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                var userViewModel = new JwtViewModel();
                mapper.Map<User, JwtViewModel>(user, userViewModel);                
                userViewModel.Token = this.authJwtManager.GenerateToken(user); 
                return userViewModel;
            }
            else
            {
                throw new ArgumentException();
            }
            throw new ArgumentException("It's Ok");
        }
    }
}

