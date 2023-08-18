using AutoMapper;
using ContactList.Domain.Interfaces;
using ContactList.Domain.Models.Entities;
using ContactList.Service.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ContactList.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactCategoryController : ControllerBase
    {
        private readonly IContactCategoryService _contactCategoryService;
        private readonly IMapper _mapper;

        public ContactCategoryController(IContactCategoryService contactCategoryService, IMapper mapper)
        {
            _contactCategoryService = contactCategoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ContactCategory>>> GetAll()
        {
            var task = await _contactCategoryService.GetAllContactsAsync();
            var dto = _mapper.Map<List<ContactCategoryListDto>>(task);
            return Ok(dto);
        }
    }
}
