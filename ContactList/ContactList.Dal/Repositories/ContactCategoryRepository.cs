using ContactList.Dal.Context;
using ContactList.Domain.Interfaces;
using ContactList.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactList.Dal.Repositories
{
    public class ContactCategoryRepository : IContactCategoryRepository
    {
        private readonly ContactlistDbContext _dbContext;

        public ContactCategoryRepository(ContactlistDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }
        public async Task<IEnumerable<ContactCategory>> GetAllCategoriesAsync()
        {
            return await _dbContext.Set<ContactCategory>()
                .Include(c => c.Subcategories)
                .ToListAsync();
        }
    }
}
