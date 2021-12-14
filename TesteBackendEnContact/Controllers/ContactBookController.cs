using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteBackendEnContact.Controllers.Models;
using TesteBackendEnContact.Core.Domain.ContactBook;
using TesteBackendEnContact.Core.Interface.ContactBook;
using TesteBackendEnContact.Repository.Interface;

namespace TesteBackendEnContact.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactBookController : ControllerBase
    {
        private readonly ILogger<ContactBookController> _logger;
        private readonly IContactBookRepository _contactBookRepository;

        public ContactBookController(ILogger<ContactBookController> logger, IContactBookRepository contactBookRepository)
        {
            _logger = logger;
            _contactBookRepository = contactBookRepository;
        }

        [HttpPost]
        public async Task<IContactBook> Post([FromBody] PostContactBookRequest contactBook)
        {
            return await _contactBookRepository.SaveAsync(contactBook.ToContactBook());
        }

        [HttpPut]
        public async Task<ActionResult<IContactBook>> Put(PutContactBookRequest contactBook)
        {
            return Ok(await _contactBookRepository.Put(contactBook.ToContactBook()));
        }   

        [HttpDelete]
        public async Task Delete(int id)
        {
            await _contactBookRepository.DeleteAsync(id);
        }

        [HttpGet]
        public async Task<IEnumerable<IContactBook>> Get()
        {
            return await _contactBookRepository.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<IContactBook> Get(int id)
        {
            return await _contactBookRepository.GetAsync(id);
        }
    }
}
