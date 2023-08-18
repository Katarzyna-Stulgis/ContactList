using AutoMapper;
using ContactList.Domain.Models.Entities;
using ContactList.Service.Dtos;

namespace ContactList.Service.Profiles
{
    public class ContactProfile:Profile
    {
        public ContactProfile()
        {
            CreateMap<ContactCategory, ContactCategoryDto>().ReverseMap();
            CreateMap<Contact, ContactDto>().ReverseMap();
        }
    }
}
