using System;
using OpenQA.Selenium;
using EcommerceTests.Core;
using System.Threading.Tasks;
using System.Security.Claims;

namespace EcommerceTests.PageObjects
{
    public class ProductsPage : BasePage
    {
        private List<IWebElement> ProductsNamesList;
        private List<IWebElement> ProductsFavoriteButtonsList;

        // XPath для продукта по имени
        private By GetFavoriteButton(string productName) =>
            By.XPath($"//div[contains(@class,'product')]//h5[text()='{productName}']/ancestor::div[contains(@class,'product')]//button[contains(@class,'favorite')]");

        private By ProductNames => By.XPath("//div[contains(@class, 'flex flex')]/a[contains(@class, 'text-lg')]");
        private By AddToFavoritesButtons => By.XPath("//div[contains(@class, 'flex flex')]//button[@class = ' cursor-pointer']");

        public ProductsPage() : base(DriverManager.Driver)
        {            
        }

        public ProductsPage InitializeProducts()
        {
            ProductsNamesList = Driver.FindElements(ProductNames).ToList();
            ProductsFavoriteButtonsList = Driver.FindElements(AddToFavoritesButtons).ToList();
            return this;
        }

        public ProductsPage ClickFavoriteButton(int index)
        {
            if (index < 0 || index >= ProductsFavoriteButtonsList.Count)
            {
                throw new IndexOutOfRangeException();
            }
            else
            { 
                ProductsFavoriteButtonsList[index].Click();
            }
            return this;
        }

        public string GetProductName(int index)
        { 
            if (index < 0 || index >= ProductsNamesList.Count)
            {
                throw new IndexOutOfRangeException();
            }
            else
            { 
               return ProductsNamesList[index].Text;
            }
        }

        public FavoritesPage GoToFavoritesPage() 
        {
            Driver.FindElement(By.XPath("//button[contains(@id,'radix')]")).Click();
            Driver.FindElement(By.XPath("//*[contains(@id,'radix')]/div[@role = 'group']/div")).Click();

            return new FavoritesPage();

        }



    }
}
