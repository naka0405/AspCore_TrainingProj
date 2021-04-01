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

        /// <summary>
        /// Creates an instance of UserSrvice.
        /// </summary>
        /// <param name="userManager">Instance of UserManager.</param>
        /// <param name="manager">Instance of AuthJwtManager</param>
        /// <param name="mapper">Instance of Mapper.</param>
        /// <param name="signInManager">Instance of SignInManager.</param>
        public UserService(UserManager<User> userManager, IAuthJwtManager manager, IMapper mapper, SignInManager<User> signInManager)//UserManager<User> manager, SignInManager<User> signInManager
        {
            this.userManager = userManager;
            this.mapper = mapper;
            this.signInManager = signInManager;
            this.authJwtManager = manager;
        }

        ///<inheritdoc/>
        public async Task<JwtViewModel> LogIn(LoginUserViewModel model)
        {
            var user = await userManager.FindByNameAsync(model.Login);
            string errorMessage = "A user with specified login wasn't found!";
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
                    throw new ArgumentException(errorMessage);
                }
            }
            throw new ArgumentException(errorMessage); ;
        }

        ///<inheritdoc/>
        public async Task<JwtViewModel> Registration(RegistrationUserViewModel model)
        {
            string errorMessage = "Server error!";
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
                throw new ArgumentException(errorMessage);
            }
            throw new ArgumentException(errorMessage);
        }
    }
}

