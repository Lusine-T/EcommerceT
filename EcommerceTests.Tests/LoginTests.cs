using EcommerceTests.Builders;
using EcommerceTests.Core;
using EcommerceTests.PageObjects;
using FluentAssertions;
using Xunit;

namespace EcommerceTests.Tests
{
   
    public class LoginTests : BaseTest
    {
        // ---------- POSITIVE DATA ----------
        public static IEnumerable<object[]> ValidUsers =>
            Config.Browsers.SelectMany(browser => new[]
            {
                new object[] { browser, "test@qabrains.com" },
                new object[] { browser, "practice@qabrains.com" },
                new object[] { browser, "student@qabrains.com" }
            });

        // ---------- NEGATIVE DATA ----------
        public static IEnumerable<object[]> InvalidUsers =>
            Config.Browsers.SelectMany(browser => new[]
            {
                new object[] { browser, "wrong@example.com", "Password123" },
                new object[] { browser, "test@qabrains.com", "wrongpassword" },
                new object[] { browser, "", "Password123" },
                new object[] { browser, "test@qabrains.com", "" },
                new object[] { browser, "", "" }
            });

        // General Data Provider only with browsers
        public static IEnumerable<object[]> Browsers =>
            Config.Browsers.SelectMany(browser => new[]
            {
                new object[] {browser}
            });

        // POSITIVE TEST

        [Theory]
        [MemberData(nameof(ValidUsers))]
        public void Login_WithValidCredentials_ShouldLoginSuccessfully(string browser, string email)
        {
            // Arrange
            Setup(browser);
            LogHelper.Info($"[POSITIVE] Login with user: {email}");

            var user = new UserBuilder()
                .WithEmail(email)
                .WithPassword("Password123")
                .Build();

            var loginPage = new LoginPage();

            // Act
            loginPage.Login(user.Email, user.Password);

            // Assert
            DriverManager.Driver.Url
                .Should().Contain("dashboard", "user should be redirected after successful login");

            LogHelper.Info("Login successful - assertion passed");

        }

        // NEGATIVE TEST (UC-1)        
        [Theory]
        [MemberData(nameof(InvalidUsers))]
        public void Login_WithInvalidCredentials_ShouldShowErrorMessagesGeneral(string browser, string email, string password)
        {
            // Arrange
            Setup(browser);
            LogHelper.Info($"[NEGATIVE] Login attempt: {email}");

            var user = new UserBuilder()
                .WithEmail(email)
                .WithPassword(password)
                .Build();

            var loginPage = new LoginPage();

            // Act
            loginPage.Login(user.Email, user.Password);

            // Assert
            loginPage.InitializePasswordError();
            loginPage.InitializeUsernameError();

            loginPage.GetUsernameError()
                     .Should().Contain("Username is incorrect");

            loginPage.GetPasswordError()
                     .Should().Contain("Password is incorrect");

            LogHelper.Info("Error messages validated successfully");

        }

        // ---------- NEGATIVE DATA ----------
       

        // NEGATIVE TEST (UC-1)        
        [Theory]
        [MemberData(nameof(Browsers))]
        public void Login_WithEmptyPassword_ShouldShowErrorMessages(string browser)
        {
            // Arrange
            Setup(browser);
            LogHelper.Info($"[NEGATIVE] Login attempt: ");

            var user = new UserBuilder()
                .WithEmail("test@qabrains.com")
                .WithPassword("")
                .Build();

            var loginPage = new LoginPage();

            // Act
            loginPage.Login(user.Email, user.Password);

            // Assert
            loginPage.InitializePasswordError();

            loginPage.GetPasswordError()
                     .Should().Contain("Password is a required field");

            LogHelper.Info("Error messages validated successfully");

            // Cleanup
            
        }


        // ---------- NEGATIVE DATA ----------
        
        // NEGATIVE TEST (UC-1)        
        [Theory]
        [MemberData(nameof(Browsers))]
        public void Login_WithInvalidCredentials_ShouldShowErrorMessages(string browser)
        {
            // Arrange
            Setup(browser);
            LogHelper.Info($"[NEGATIVE] Login attempt: ");

            var user = new UserBuilder()
                .WithEmail("wrong@example.com")
                .WithPassword("wrongpassword")
                .Build();

            var loginPage = new LoginPage();

            // Act
            loginPage.Login(user.Email, user.Password);

            // Assert
            loginPage.InitializePasswordError();
            loginPage.InitializeUsernameError();

            loginPage.GetUsernameError()
                     .Should().Contain("Username is incorrect");

            loginPage.GetPasswordError()
                     .Should().Contain("Password is incorrect");

            LogHelper.Info("Error messages validated successfully");

        }


        public void Dispose()
        {
            TearDown();
        }
    }
}


/*
  //div[contains(@class, 'flex flex')]/a[contains(@class, 'text-lg')]
  //div[contains(@class, 'flex flex')]//button[@class = ' cursor-pointer']



 * */