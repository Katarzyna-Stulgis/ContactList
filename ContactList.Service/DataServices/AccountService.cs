using ContactList.Domain.Interfaces;
using ContactList.Domain.Models;
using ContactList.Domain.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ContactList.Service.DataServices
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly AuthenticationSettings _authenticationSettings;

        public AccountService(IPasswordHasher<User> passwordHasher, IAccountRepository accountRepository, AuthenticationSettings authenticationSettings)
        {
            _accountRepository = accountRepository;
            _passwordHasher = passwordHasher;
            _authenticationSettings = authenticationSettings;
        }
        public string GenerateJwt(User entity)
        {
            var user = _accountRepository.GetUserByEmail(entity.Email);

            if (user is null)
            {
                throw new Exception("Invalid e-mail or password");
            }

            var result = _passwordHasher.VerifyHashedPassword(user, user.Password, entity.Password);

            if (result == PasswordVerificationResult.Failed)
            {
                throw new Exception("Invalid e-mail or password");
            }

            // set of information that is contained inside a JWT token
            var claims = new List<Claim>()
            {
                new Claim("UserId", user.UserId.ToString()),
                new Claim("E-mail", user.Email.ToString()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

            //creating a jwt token
            var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer,
                _authenticationSettings.JwtIssuer,
                claims,
                expires: expires,
                signingCredentials: cred);

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }

        public async Task<User> Register(User entity)
        {
            return await _accountRepository.Register(entity);
        }
    }
}
