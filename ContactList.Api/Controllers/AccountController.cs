using ContactList.Domain.Interfaces;
using ContactList.Domain.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ContactList.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService userService)
        {
            _accountService = userService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> RegisterUser([FromBody] User user)
        {
            //var user = _mapper.Map<User>(dto);
            await _accountService.Register(user);

            return Ok(user.UserId);
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] User user)
        {
           // var user = _mapper.Map<User>(dto);
            string token = _accountService.GenerateJwt(user);

            return Ok(token);
        }
    }
}
