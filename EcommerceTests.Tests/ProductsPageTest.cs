using EcommerceTests.Builders;
using EcommerceTests.Core;
using EcommerceTests.PageObjects;
using FluentAssertions;

namespace EcommerceTests.Tests
{
    public class ProductsPageTest: BaseTest 
    {
        [Fact]       
        public void AddToFavoritesTest()
        {
            Setup("chrome");
            LogHelper.Info($"[NEGATIVE] Login attempt: ");

            var user = new UserBuilder()
                .WithEmail("test@qabrains.com")
                .WithPassword("Password123")
                .Build();

            var loginPage = new LoginPage();


            ProductsPage page = loginPage.Login(user.Email, user.Password);
            page.InitializeProducts();

            string productName1 = page.ClickFavoriteButton(0).GetProductName(0);
            string productName2 = page.ClickFavoriteButton(1).GetProductName(1);

            FavoritesPage favoritesPage = page.GoToFavoritesPage();
            List<string> productNames = favoritesPage.GetProductNames();

            productNames[0]
                     .Should().Contain(productName1);

            productNames[1]
                     .Should().Contain(productName2);


            
        }
    }
}