namespace Companies.Domain.Models
{
    public class Company
    {
        //Company Name, Years in Business, Contact Name, Contact Phone Number, Contact Email
        public string CompanyName { get; set; }
        public int? YearsInBusiness { get; set; }
        public string ContactName { get; set; }
        public string ContactPhoneNumber { get; set; }
        public string ContactEmail { get; set; }
    }
}
