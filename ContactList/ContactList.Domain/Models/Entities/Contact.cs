namespace ContactList.Domain.Models.Entities
{
    public class Contact
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }

        public Guid ContactCategoryId { get; set; }
        public ContactCategory? Category { get; set; }

        public string? Subcategory { get; set; }
    }
}
