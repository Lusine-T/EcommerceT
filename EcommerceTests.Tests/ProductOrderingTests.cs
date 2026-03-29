using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceTests.Core;
using EcommerceTests.PageObjects;
using FluentAssertions;
using Xunit;

namespace EcommerceTests.Tests
{
    public class ProductOrderingTests : BaseTest
    {
        [Theory]
        [MemberData(nameof(Browsers))]
        public void OrderProductsByPriceLowToHigh(string browser)
        {
            Setup(browser);
            LogHelper.Info("Starting OrderProductsByPriceLowToHigh test.");

            LoginPage loginPage = new LoginPage();
            loginPage.Login("test@qabrains.com", "Password123");

            ProductsPage productsPage = new ProductsPage();
            productsPage.InitializeProducts();
            productsPage.SelectSortOption("Price: Low to High");
            productsPage.InitializeProducts();

            List<double> actualPrices = productsPage.GetProductPrices();
            List<double> expectedPrices = actualPrices.OrderBy(p => p).ToList();

            expectedPrices.Should().BeEqualTo(actualPrices);

            LogHelper.Info("OrderProductsByPriceLowToHigh test finished successfully.");
        }
    }
}