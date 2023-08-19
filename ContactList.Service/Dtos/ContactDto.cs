namespace ContactList.Service.Dtos
{
    public class ContactDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }

        public Guid ContactCategoryId { get; set; }
        public ContactCategoryDto? Category { get; set; }
        public string? Subcategory { get; set; }
    }
}
