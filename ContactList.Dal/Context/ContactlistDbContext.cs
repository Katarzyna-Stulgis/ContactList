using ContactList.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactList.Dal.Context
{
    public class ContactlistDbContext : DbContext
    {
        public ContactlistDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactCategory> Categroies { get; set; }
        public DbSet<ContactSubcategory> Subcategories { get; set; }

        protected override async void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactCategory>()
              .HasMany(c => c.Subcategories)
              .WithOne(s => s.ContactCategory)
              .HasForeignKey(s => s.ContactCategoryId);

            // Konfiguracja relacji między kontaktem a kategorią
            modelBuilder.Entity<Contact>()
                .HasOne(c => c.Category)
                .WithMany(cat => cat.Contacts)
                .HasForeignKey(c => c.ContactCategoryId);


            //data
            var user1 = new User
            {
                UserId = Guid.NewGuid(),
                Email = "user1@contactlistapp.com",
                Password = "!@#Password123"
            };

            var category1 = new ContactCategory
            {
                Id = Guid.NewGuid(),
                Name = "służbowy"
            };

            var category2 = new ContactCategory
            {
                Id = Guid.NewGuid(),
                Name = "prywatny"
            };

            var category3 = new ContactCategory
            {
                Id = Guid.NewGuid(),
                Name = "inny"
            };

            var subcategory1 = new ContactSubcategory
            {
                Id = Guid.NewGuid(),
                ContactCategoryId = category1.Id,
                Name = "szef"
            };

            var subcategory2 = new ContactSubcategory
            {
                Id = Guid.NewGuid(),
                ContactCategoryId = category1.Id,
                Name = "klient"
            };

            var contact1 = new Contact
            {
                Id = Guid.NewGuid(),
                FirstName = "Jan",
                LastName = "Kowalski",
                Email = "jan.kowalski@contactlistapp.com",
                PhoneNumber = "123456789",
                BirthDate = new DateTime(1995, 1, 1),
                ContactCategoryId = category1.Id,
                Subcategory = subcategory1.Name,
            };

            var contact2 = new Contact
            {
                Id = Guid.NewGuid(),
                FirstName = "Adam",
                LastName = "Nowak",
                Email = "adam.nowak@contactlistapp.com",
                PhoneNumber = "987654321",
                BirthDate = new DateTime(1990, 1, 1),
                ContactCategoryId = category1.Id,
                Subcategory = subcategory2.Name,
            };

            // Add data to Db
            modelBuilder.Entity<User>().HasData(user1);
            modelBuilder.Entity<Contact>().HasData(contact1, contact2);
            modelBuilder.Entity<ContactCategory>().HasData(category1, category2, category3);
            modelBuilder.Entity<ContactSubcategory>().HasData(subcategory1, subcategory2);
        }
    }
}
