using Companies.Domain.Models;

namespace Companies.DataAccess.FileFormats
{
    public class CompanyFileCommaFormat : ICompanyFileFormat
    {
        public string FileName => "comma.txt";//Company Name, Contact Name, Contact Phone Number, Years in business, Contact Email

        public char Separator => ',';

        public Company CreateCompany(string[] properties)
        {
            return new Company
            {
                CompanyName = properties[0].Trim(),
                ContactName = properties[1].Trim(),
                ContactPhoneNumber = properties[2].Trim(),
                YearsInBusiness = int.Parse(properties[3]),
                ContactEmail = properties[4].Trim()
            };
        }
    }
}
