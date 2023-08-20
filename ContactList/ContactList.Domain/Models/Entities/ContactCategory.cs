namespace ContactList.Domain.Models.Entities
{
    public class ContactCategory
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<Contact>? Contacts { get; set; }
        public ICollection<ContactSubcategory>? Subcategories { get; set; }
    }
}
