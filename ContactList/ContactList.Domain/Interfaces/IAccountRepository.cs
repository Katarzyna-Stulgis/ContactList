using ContactList.Domain.Models.Entities;

namespace ContactList.Domain.Interfaces
{
    public interface IAccountRepository
    {
        Task<User> Register(User entity);
        User GetUserByEmail(string email);
    }
}
