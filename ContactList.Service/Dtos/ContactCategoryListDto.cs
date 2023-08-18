namespace ContactList.Service.Dtos
{
    public class ContactCategoryListDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public List<ContactSubcategoryDto>? contactSubcategories { get; set; }
    }
}
