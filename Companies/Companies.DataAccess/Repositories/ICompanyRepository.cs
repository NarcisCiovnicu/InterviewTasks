using Companies.DataAccess.FileFormats;
using Companies.Domain.Models;

namespace Companies.DataAccess.Repositories
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> ReadFromFile(ICompanyFileFormat companyFileFormat);
    }
}
