using Companies.BusinessLogic.Services;
using Companies.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Companies.Controllers
{
    [ApiController]
    [Route("api/{controller}/{action}")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public async Task<IEnumerable<Company>> GetAll()
        {
            return await _companyService.GetAll();
        }
    }
}