using Microsoft.VisualStudio.TestTools.UnitTesting;
using OneTimePassword.BusinessLogic.Services;
using OneTimePassword.Domain.Models;

namespace OneTimePassword.BusinessLogicTests.Services
{
    [TestClass]
    public class PasswordGeneratorServiceTests
    {
        [TestMethod]
        public void GetGeneratedPassword_Should_Return_Same_Password_for_the_same_user_requesting_in_less_then_30_seconds()
        {

            var request1 = new UserOtpRequest
            {
                UserId = "user1",
                CurrentTime = DateTime.Now
            };
            var request2 = new UserOtpRequest
            {
                UserId = "user1",
                CurrentTime = request1.CurrentTime.AddSeconds(10)
            };

            var service = new PasswordGeneratorService();

            var password1 = service.GetGeneratedPassword(request1);
            var password2 = service.GetGeneratedPassword(request2);

            Assert.AreEqual(password1.Password, password2.Password);
        }

        [TestMethod]
        public void GetGeneratedPassword_Should_Return_Different_Password_for_the_same_user_requesting_after_30_seconds()
        {
            var request1 = new UserOtpRequest
            {
                UserId = "user1",
                CurrentTime = DateTime.Now
            };
            var request2 = new UserOtpRequest
            {
                UserId = "user1",
                CurrentTime = request1.CurrentTime.AddSeconds(40)
            };

            var service = new PasswordGeneratorService();

            var password1 = service.GetGeneratedPassword(request1);
            var password2 = service.GetGeneratedPassword(request2);

            Assert.AreNotEqual(password1.Password, password2.Password);
        }

        [TestMethod]
        public void GetGeneratedPassword_Should_Return_Different_Password_for_different_users_requesting_in_less_than_30_seconds()
        {
            var request1 = new UserOtpRequest
            {
                UserId = "user1",
                CurrentTime = DateTime.Now
            };
            var request2 = new UserOtpRequest
            {
                UserId = "user2",
                CurrentTime = request1.CurrentTime.AddSeconds(10)
            };

            var service = new PasswordGeneratorService();

            var password1 = service.GetGeneratedPassword(request1);
            var password2 = service.GetGeneratedPassword(request2);

            Assert.AreNotEqual(password1.Password, password2.Password);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetGeneratedPassword_Should_Throw_an_Exception_if_user_id_is_not_valid()
        {
            var request1 = new UserOtpRequest
            {
                UserId = "",
                CurrentTime = DateTime.Now
            };

            var service = new PasswordGeneratorService();

            var password1 = service.GetGeneratedPassword(request1);
        }
    }
}

