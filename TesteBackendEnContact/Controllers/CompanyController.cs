using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteBackendEnContact.Controllers.Models;
using TesteBackendEnContact.Core.Interface.ContactBook.Company;
using TesteBackendEnContact.Repository.Interface;

namespace TesteBackendEnContact.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ILogger<CompanyController> _logger;
        private readonly ICompanyRepository _companyRepository;

        public CompanyController(ILogger<CompanyController> logger, ICompanyRepository companyRepository)
        {
            _logger = logger;
            _companyRepository = companyRepository;
        }

        [HttpPost]
        public async Task<ActionResult<ICompany>> Post(PostCompanyRequest company)
        {
            return Ok(await _companyRepository.SaveAsync(company.ToCompany()));
        }

        [HttpDelete]
        public async Task Delete(int id)
        {
            await _companyRepository.DeleteAsync(id);
        }

        [HttpGet]
        public async Task<IEnumerable<ICompany>> Get()
        {
            return await _companyRepository.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ICompany> Get(int id)
        {
            return await _companyRepository.GetAsync(id);
        }

        [HttpPut]
        public async Task<ActionResult<ICompany>> Put([FromBody] PutCompanyRequest company)
        {
            return Ok(await _companyRepository.Put(company.ToCompany()));
        }
    }
}
