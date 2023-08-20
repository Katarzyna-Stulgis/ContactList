using ContactList.Domain.Models.Entities;

namespace ContactList.Domain.Interfaces
{
    public interface IAccountService
    {
        Task<User> Register(User entity);
        string GenerateJwt(User entity);
    }
}
