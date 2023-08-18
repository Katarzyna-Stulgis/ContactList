using ContactList.Domain.Models.Entities;

namespace ContactList.Domain.Interfaces
{
    public interface IContactService
    {
        Task<IEnumerable<Contact>> GetAllContactsAsync();
        Task<Contact> GetContactByIdAsync(Guid id);
        Task<Contact> AddContactAsync(Contact contact);
        Task<Contact> UpdateContactAsync(Contact contact);
        Task<Contact> DeleteContactAsync(Guid id);
    }
}
