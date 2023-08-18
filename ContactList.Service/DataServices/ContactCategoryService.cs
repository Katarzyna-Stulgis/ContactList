using ContactList.Domain.Interfaces;
using ContactList.Domain.Models.Entities;

namespace ContactList.Service.DataServices
{
    public class ContactCategoryService : IContactCategoryService
    {
        private readonly IContactCategoryRepository _contactCategoryRepository; 
        public ContactCategoryService(IContactCategoryRepository contactCategoryRepository)
        {
            _contactCategoryRepository = contactCategoryRepository;
        }

        public async Task<IEnumerable<ContactCategory>> GetAllContactsAsync()
        {
           return await _contactCategoryRepository.GetAllContactsAsync();
        }
    }
}
