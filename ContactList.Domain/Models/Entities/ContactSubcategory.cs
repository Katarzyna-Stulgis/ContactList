namespace ContactList.Domain.Models.Entities
{
    public class ContactSubcategory
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public string Name { get; set; }

        public Guid ContactCategoryId { get; set; }
        public ContactCategory? Category { get; set; }
    }
}
