namespace ContactList.Domain.Models.Entities
{
    public class ContactSubcategory
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid ContactCategoryId { get; set; }
        public ContactCategory? ContactCategory { get; set; }
    }
}
