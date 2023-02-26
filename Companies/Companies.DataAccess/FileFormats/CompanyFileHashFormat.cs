using Companies.Domain.Models;

namespace Companies.DataAccess.FileFormats
{
    public class CompanyFileHashFormat : ICompanyFileFormat
    {
        public string FileName => "hash.txt";//Company Name, Year Founded, Contact Name, Contact Phone Number

        public char Separator => '#';

        public Company CreateCompany(string[] properties)
        {
            return new Company
            {
                CompanyName = properties[0].Trim(),
                YearsInBusiness = DateTime.Now.Year - int.Parse(properties[1]),
                ContactName = properties[2].Trim(),
                ContactPhoneNumber = properties[3].Trim()
            };
        }
    }
}
