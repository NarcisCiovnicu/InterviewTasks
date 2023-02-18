using OneTimePassword.Domain.Models;
using OneTimePassword.Domain.Validators;

namespace OneTimePassword.BusinessLogic.Services
{
    public class PasswordGeneratorService : IPasswordGeneratorService
    {
        private readonly Dictionary<string, GeneratedPassword> GeneratedPasswords;

        public PasswordGeneratorService()
        {
            GeneratedPasswords = new Dictionary<string, GeneratedPassword>();
        }

        public GeneratedPassword GetGeneratedPassword(UserOtpRequest userOtpRequest)
        {
            UserOtpRequestValidator.ValidateRequest(userOtpRequest);

            var generatedPassword = GeneratedPasswords.GetValueOrDefault(userOtpRequest.UserId);
            if (generatedPassword != null)
            {
                var expirationTime = generatedPassword.GeneratedTime.AddSeconds(30);
                if (expirationTime < userOtpRequest.CurrentTime.ToUniversalTime())
                {
                    generatedPassword = GenerateAndSaveNewPassword(userOtpRequest);
                }
            }
            else
            {
                generatedPassword = GenerateAndSaveNewPassword(userOtpRequest);
            }
            return generatedPassword;
        }

        private GeneratedPassword GenerateAndSaveNewPassword(UserOtpRequest userOtpRequest)
        {
            GeneratedPassword generatedPassword = GenerateNewPassword(userOtpRequest.CurrentTime);
            GeneratedPasswords[userOtpRequest.UserId] = generatedPassword;
            return generatedPassword;
        }

        private GeneratedPassword GenerateNewPassword(DateTime currentTime)
        {
            var rnd = new Random();
            return new GeneratedPassword
            {
                Password = $"{rnd.Next(10)}{rnd.Next(10)}{rnd.Next(10)} {rnd.Next(10)}{rnd.Next(10)}{rnd.Next(10)}",
                GeneratedTime = currentTime.ToUniversalTime()
            };
        }
    }
}
