using ContactList.Domain.Interfaces;
using ContactList.Domain.Models.Entities;

namespace ContactList.Service.DataServices
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _repository;
        public ContactService(IContactRepository repository)
        {
            _repository = repository;
        }

        public async Task<Contact> AddContactAsync(Contact contact)
        {
            return await _repository.AddContactAsync(contact);
        }

        public async Task<Contact> DeleteContactAsync(Guid id)
        {
            return await _repository.DeleteContactAsync(id);
        }

        public async Task<IEnumerable<Contact>> GetAllContactsAsync(Guid userId)
        {
            return await _repository.GetAllContactsAsync(userId);
        }

        public async Task<Contact> GetContactByIdAsync(Guid id)
        {
            return await _repository.GetContactByIdAsync(id);
        }

        public async Task<Contact> UpdateContactAsync(Contact contact)
        {
            return await _repository.UpdateContactAsync(contact);
        }
    }
}
