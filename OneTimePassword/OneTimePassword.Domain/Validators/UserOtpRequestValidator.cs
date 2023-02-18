using OneTimePassword.Domain.Models;

namespace OneTimePassword.Domain.Validators
{
    public class UserOtpRequestValidator
    {
        public static void ValidateRequest(UserOtpRequest userOtpRequest)
        {
            if (string.IsNullOrWhiteSpace(userOtpRequest.UserId))
            {
                throw new ArgumentException("User id cannot be null or empty");
            }
        }
    }
}
