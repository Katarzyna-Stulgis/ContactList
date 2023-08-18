using ContactList.Dal.Context;
using ContactList.Domain.Interfaces;
using ContactList.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactList.Dal.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly ContactlistDbContext _dbContext;

        public ContactRepository(ContactlistDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }
        public async Task<Contact> AddContactAsync(Contact contact)
        {
            _dbContext.Set<Contact>().Add(contact);
            await _dbContext.SaveChangesAsync();

            return contact;
        }

        public async Task<Contact> DeleteContactAsync(Guid id)
        {
            var contact = await _dbContext.Set<Contact>().FindAsync(id);

            if (contact == null)
            {
                throw new Exception("Contact not found");
            }

            _dbContext.Set<Contact>().Remove(contact);
            await _dbContext.SaveChangesAsync();

            return contact;
        }

        public async Task<IEnumerable<Contact>> GetAllContactsAsync()
        {
            return await _dbContext.Set<Contact>().ToListAsync();
        }

        public async Task<Contact> GetContactByIdAsync(Guid id)
        {
            var contact = await _dbContext.Set<Contact>().
                Where(c => c.Id == id)
                .Include(c => c.Category)
                .FirstOrDefaultAsync();

            if (contact == null)
            {
                throw new Exception("Contact not found");
            }
            return contact;
        }

        public async Task<Contact> UpdateContactAsync(Contact contact)
        {
            _dbContext.Entry(contact).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            return contact;
        }
    }
}
