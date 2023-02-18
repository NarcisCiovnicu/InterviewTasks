using System.ComponentModel.DataAnnotations;

namespace OneTimePassword.Domain.Models
{
    public class UserOtpRequest
    {
        [Required]
        public String UserId { get; set; }
        public DateTime CurrentTime { get; set; }
    }
}
