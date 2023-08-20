using AutoMapper;
using ContactList.Domain.Interfaces;
using ContactList.Domain.Models.Entities;
using ContactList.Service.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ContactList.Api.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public AccountController(IAccountService userService, IMapper mapper)
        {
            _accountService = userService;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> RegisterUser([FromBody] RegisterUserDto dto)
        {
            var user = _mapper.Map<User>(dto);
            await _accountService.Register(user);

            return Ok(user.UserId);
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginDto dto)
        {
            var user = _mapper.Map<User>(dto);
            string token = _accountService.GenerateJwt(user);

            return Ok(token);
        }
    }
}
