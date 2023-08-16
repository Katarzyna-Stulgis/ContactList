using ContactList.Domain.Models.Entities;

namespace ContactList.Domain.Interfaces
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetAllContactsAsync(Guid userId);
        Task<Contact> GetContactByIdAsync(Guid id);
        Task<Contact> AddContactAsync(Contact contact);
        Task<Contact> UpdateContactAsync(Contact contact);
        Task<Contact> DeleteContactAsync(Guid id);
    }
}
