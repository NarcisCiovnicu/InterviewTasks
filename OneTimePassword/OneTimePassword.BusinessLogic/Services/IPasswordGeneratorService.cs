using OneTimePassword.Domain.Models;

namespace OneTimePassword.BusinessLogic.Services
{
    public interface IPasswordGeneratorService
    {
        GeneratedPassword GetGeneratedPassword(UserOtpRequest userOtpRequest);
    }
}
