using Companies.Domain.Models;

namespace Companies.BusinessLogic.Services
{
    public interface ICompanyService
    {
        Task<IEnumerable<Company>> GetAll();
    }
}
