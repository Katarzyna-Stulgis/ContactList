using AutoMapper;
using ContactList.Domain.Interfaces;
using ContactList.Domain.Models.Entities;
using ContactList.Service.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ContactList.Api.Controllers
{
    [Route("api/Contacts")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Contact>>> GetAll()
        {
            var task = await _contactService.GetAllContactsAsync();
            return Ok(task);
        }

        [HttpGet("{guid}")]
        public async Task<ActionResult<Contact>> Get([FromRoute] Guid guid)
        {
            var task = await _contactService.GetContactByIdAsync(guid);
            if (task == null)
            {
                return NotFound("Flashcard not found");
            }
            var dto =_mapper.Map<ContactDto>(task);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<Contact>> Add([FromBody] Contact contact)
        {
            Contact task;
            try
            {
                task = await _contactService.AddContactAsync(contact);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok(task);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromRoute] Guid id, [FromBody] Contact contact)
        {
            var task = await _contactService.UpdateContactAsync(contact);
            return Ok(task.Id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            await _contactService.DeleteContactAsync(id);

            return Ok(id);
        }
    }
}
