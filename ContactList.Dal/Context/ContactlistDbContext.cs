using ContactList.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactList.Dal.Context
{
    public class ContactlistDbContext : DbContext
    {
        public ContactlistDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
