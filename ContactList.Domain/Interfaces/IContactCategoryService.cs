using ContactList.Domain.Models.Entities;

namespace ContactList.Domain.Interfaces
{
    public interface IContactCategoryService
    {
        Task<IEnumerable<ContactCategory>> GetAllContactsAsync();
    }
}
