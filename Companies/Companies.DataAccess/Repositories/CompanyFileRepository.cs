using Companies.DataAccess.FileFormats;
using Companies.Domain;
using Companies.Domain.Models;
using Microsoft.Extensions.Configuration;

namespace Companies.DataAccess.Repositories
{
    public class CompanyFileRepository : ICompanyRepository
    {
        private readonly string _filesLocation;

        public CompanyFileRepository(IConfiguration configuration)
        {
            _filesLocation = configuration["ResourceFileLocation"];
        }

        public async Task<IEnumerable<Company>> ReadFromFile(ICompanyFileFormat companyFileFormat)
        {
            List<Company> companies = new();
            try
            {
                var lines = await File.ReadAllLinesAsync($"{_filesLocation}{companyFileFormat.FileName}");
                foreach (string line in lines)
                {
                    if (string.IsNullOrEmpty(line))
                    {
                        continue;
                    }
                    var properties = line.Split(companyFileFormat.Separator);
                    Company company = companyFileFormat.CreateCompany(properties);
                    companies.Add(company);
                }
            }
            catch (IOException ex)
            {
                throw new CustomExeption($"Resource file not found - {_filesLocation}{companyFileFormat.FileName}", ex);
            }
            catch (FormatException ex)
            {
                throw new CustomExeption($"Recource file has a wrong format - {companyFileFormat.FileName}", ex);
            }
            return companies;
        }
    }
}
