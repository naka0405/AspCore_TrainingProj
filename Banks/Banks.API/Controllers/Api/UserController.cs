﻿using Banks.BusinessLogic.Interfaces;
using Banks.Users.ViewModels;
using Banks.ViewModels.ViewModels;
using Banks.ViewModels.ViewModels.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Banks.API.Controllers.Api
{
    /// <summary>
    /// The controller class to user authorization control.
    /// Contains all methods for performing user.
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [AllowAnonymous]
    public class UserController : Controller
    {
        private readonly IUserService userService;
        
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        /// <summary>
        /// Method for user authentication.
        /// </summary>
        /// <param name="model">Gets or sets Login and password </param>
        /// <returns>ViewModel consists token or BadRequest with error message.</returns>
        [HttpPost]
        public async Task<IActionResult> LogIn(LoginUserViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid input");
                }
                var userViewModel = await this.userService.LogIn(model);
                return Ok(userViewModel);
            }
            catch(Exception ex)
            {
                return BadRequest(new BadRequestViewModel(ex));
            }
        }

        /// <summary>
        /// Method for set user registration that is create new user.
        /// </summary>
        /// <param name="model">Gets or sets login, email, password, password confirm,  year of birt for new user.</param>
        /// <returns>ViewModel with token or BadRequest with message.</returns>
        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationUserViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new { errorText = "Invalid username or password." });
                }
                var result = await userService.Create(model);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(new BadRequestViewModel(ex));
            }
        }
    }
}
