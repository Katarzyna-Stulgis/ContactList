using AutoMapper;
using ContactList.Domain.Models.Entities;
using ContactList.Service.Dtos;

namespace ContactList.Service.Profiles
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            // mapping dto
            CreateMap<ContactCategory, ContactCategoryDto>().ReverseMap();
            CreateMap<ContactCategory, ContactCategoryListDto>()
                .ForMember(dest => dest.ContactSubcategories, opt => opt.MapFrom(src => src.Subcategories)).ReverseMap();
            CreateMap<Contact, ContactDto>().ReverseMap();
            CreateMap<ContactSubcategory, ContactSubcategoryDto>().ReverseMap();
        }
    }
}