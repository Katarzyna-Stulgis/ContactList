using ContactList.Dal.Context;
using ContactList.Domain.Interfaces;
using ContactList.Domain.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace ContactList.Dal.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ContactlistDbContext _dbContext;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AccountRepository(IPasswordHasher<User> passwordHasher, ContactlistDbContext dbContext)
        {
            _passwordHasher = passwordHasher;
            _dbContext = dbContext;
        }
        public User GetUserByEmail(string email)
        {
            return _dbContext.Set<User>().FirstOrDefault(u => u.Email == email);
        }

        public async Task<User> Register(User entity)
        {
            var newUser = new User()
            {
                UserId = Guid.NewGuid(),
                Email = entity.Email,
            };

            var hashedPassword = _passwordHasher.HashPassword(newUser, entity.Password);
            newUser.Password = hashedPassword;

            _dbContext.Set<User>().Add(newUser);

            await _dbContext.SaveChangesAsync();

            return newUser;
        }
    }
}
