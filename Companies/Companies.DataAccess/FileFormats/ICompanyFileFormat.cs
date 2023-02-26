using Companies.Domain.Models;

namespace Companies.DataAccess.FileFormats
{
    public interface ICompanyFileFormat
    {
        string FileName { get; }
        char Separator { get; }
        Company CreateCompany(string[] properties);
    }
}
