using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceTests.Builders;
using EcommerceTests.Core;
using EcommerceTests.PageObjects;
using OpenQA.Selenium.DevTools.V143.Network;

namespace EcommerceTests.Tests
{
    public class ProductsPageTest: BaseTest 
    {
        [Fact]       
        public void AddToFavoritesTest()
        {
            // Arrange
            Setup("chrome");
            LogHelper.Info($"[NEGATIVE] Login attempt: ");

            var user = new UserBuilder()
                .WithEmail("test@qabrains.com")
                .WithPassword("Password123")
                .Build();

            var loginPage = new LoginPage();

            // Act
            ProductsPage page = loginPage.Login(user.Email, user.Password);
            page.InitializeProducts();
            // Assert
            string productName1 = page.ClickFavoriteButton(2).GetProductName(2);
            string productName2 = page.ClickFavoriteButton(4).GetProductName(4);

            page.GoToFavoritesPage();
            

        }
    }
}
