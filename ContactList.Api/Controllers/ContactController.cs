using ContactList.Domain.Interfaces;
using ContactList.Domain.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ContactList.Api.Controllers
{
    [Route("api/Contacts")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }


        [HttpGet]
        public async Task<ActionResult<List<Contact>>> GetAll(Guid userId)
        {
            var task = await _contactService.GetAllContactsAsync(userId);
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
            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<Contact>> Add([FromBody] Contact flashcard)
        {
            Contact task;
            try
            {
                task = await _contactService.AddContactAsync(flashcard);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok(task);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromRoute] Guid id, [FromBody] Contact flashcard)
        {
            var task = await _contactService.UpdateContactAsync(flashcard);
            return Ok(task.Id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            var task = await _contactService.DeleteContactAsync(id);

            return Ok(id);
        }
    }
}
