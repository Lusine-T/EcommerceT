using EcommerceTests.Builders;
using EcommerceTests.Core;
using EcommerceTests.PageObjects;
using FluentAssertions;
using Xunit;

namespace EcommerceTests.Tests
{
   
    public class LoginTests : BaseTest
    {
        [Theory]
        [MemberData(nameof(Browsers))]
        public void Login_WithInvalidCredentials_ShouldShowErrorMessages(string browser)
        {
            Setup(browser);
            LogHelper.Info($"[NEGATIVE] Login attempt: ");

            var user = new UserBuilder()
                .WithEmail("wrong@example.com")
                .WithPassword("wrongpassword")
                .Build();

            var loginPage = new LoginPage();

            loginPage.Login(user.Email, user.Password);

            loginPage.InitializePasswordError();
            loginPage.InitializeUsernameError();

            loginPage.GetUsernameError()
                     .Should().Contain("Username is incorrect");

            loginPage.GetPasswordError()
                     .Should().Contain("Password is incorrect");

            LogHelper.Info("Error messages validated successfully");

        }
    }
}