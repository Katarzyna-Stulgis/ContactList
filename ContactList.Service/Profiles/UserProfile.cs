using AutoMapper;
using ContactList.Domain.Models.Entities;
using ContactList.Service.Dtos;

namespace ContactList.Service.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<LoginDto, User>().ReverseMap();
            CreateMap<RegisterUserDto, User>().ReverseMap();
        }
    }
}
