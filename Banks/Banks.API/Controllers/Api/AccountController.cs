using Banks.BusinessLogic.Interfaces;
using Banks.ViewModels.Enums;
using Banks.ViewModels.ViewModels;
using Banks.ViewModels.ViewModels.Account;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Banks.API.Controllers
{
    /// <summary>
    /// The controller class to manage AccountEntity.
    /// Contains all methods for performing accounts.
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;
        public AccountController(IAccountService service)
        {
            accountService = service;
        }

        /// <summary>       
        /// Get all accounts.
        /// </summary>
        /// <param name="bankId">A integer precision number.</param>
        /// <param name="clientCode">A string clientCode.</param>


        [HttpGet]
        public async Task<IActionResult> GetAllByCode([FromQuery] int bankId, string clientCode)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await accountService.GetClientAccountsByCode(bankId, clientCode);
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new BadRequestViewModel(ex));
            }
            return BadRequest();
        }

        /// <summary>       
        /// Get all accounts by bankId, int currencyCode.
        /// </summary>
        /// <param name="currencyCode">A integer precision number, which matchs to enum.</param>
        [HttpGet]
        public async Task<IActionResult> GetAllByCurrency([FromQuery] int bankId, int currencyCode)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid input");
                }
                var result = await accountService.GetByCurrency(bankId, currencyCode);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new BadRequestViewModel(ex));
            }
        }

        /// <summary>       
        /// Get account by Id.
        /// </summary>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid input");
                }
                var result = await accountService.GetById<GetByIdAccountViewModel>(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new BadRequestViewModel(ex));
            }
        }

        /// <summary>       
        /// Create new account for client.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create(CreateAccountViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid input!");
                }
                var newId = await accountService.Create(model);
                if (newId > 0)
                {                   
                    return Ok(newId);
                }
                return BadRequest(new BadRequestViewModel(ErrorCodes.ServerError));
            }
            catch (Exception ex)
            {
                return BadRequest(new BadRequestViewModel(ex));
            }
        }

        /// <summary>       
        /// Update number, currency for account.
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateAccountViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid input!");
                }
                 await accountService.Update(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new BadRequestViewModel(ex));
            }
        }

        /// <summary>       
        /// Delete some account.
        /// </summary>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid input!");
                }
                await accountService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new BadRequestViewModel(ex));
            }
        }
    }
}
