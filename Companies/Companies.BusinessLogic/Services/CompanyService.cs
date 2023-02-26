using Companies.DataAccess.FileFormats;
using Companies.DataAccess.Repositories;
using Companies.Domain.Models;

namespace Companies.BusinessLogic.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly List<ICompanyFileFormat> _companyFileFormats;
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;

            _companyFileFormats = new()
            {
                new CompanyFileCommaFormat(),
                new CompanyFileHashFormat(),
                new CompanyFileHyphenFormat()
            };
        }

        public async Task<IEnumerable<Company>> GetAll()
        {
            List<Task<IEnumerable<Company>>> readFileTasks = new();
            foreach (var fileFormat in _companyFileFormats)
            {
                var task = _companyRepository.ReadFromFile(fileFormat);
                readFileTasks.Add(task);
            }

            List<Company> masterCompanyList = new();
            foreach (var companies in await Task.WhenAll(readFileTasks))
            {
                masterCompanyList.AddRange(companies);
            }

            return masterCompanyList;
        }
    }
}
