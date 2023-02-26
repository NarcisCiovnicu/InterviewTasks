using Companies.Domain.Models;

namespace Companies.DataAccess.FileFormats
{
    public class CompanyFileHyphenFormat : ICompanyFileFormat
    {
        public string FileName => "hyphen.txt";//Company Name, Year Founded, Contact Phone Number, Contact Email, Contact First Name, Contact Last Name

        public char Separator => '-';

        public Company CreateCompany(string[] properties)
        {
            return new Company
            {
                CompanyName = properties[0].Trim(),
                YearsInBusiness = DateTime.Now.Year - int.Parse(properties[1]),
                ContactPhoneNumber = properties[2].Trim(),
                ContactEmail = properties[3].Trim(),
                ContactName = $"{properties[4].Trim()} {properties[5].Trim()}"
            };
        }
    }
}
