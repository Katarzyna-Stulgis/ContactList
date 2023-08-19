using ContactList.Domain.Models.Entities;

namespace ContactList.Domain.Interfaces
{
    public interface IContactCategoryRepository
    {
        Task<IEnumerable<ContactCategory>> GetAllCategoriesAsync();
    }
}
