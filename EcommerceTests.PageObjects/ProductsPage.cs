using System.Globalization;
using System;
using System.Linq;
using System.Collections.Generic;
using OpenQA.Selenium;
using EcommerceTests.Core;
using OpenQA.Selenium.Support.UI;

namespace EcommerceTests.PageObjects
{
    public class ProductsPage : BasePage
    {
        private List<IWebElement> ProductsNamesList;
        private List<IWebElement> ProductsFavoriteButtonsList;
        private List<IWebElement> ProductsPricesList;

        private IWebElement SortDropdown => Driver.FindElement(By.XPath("//button[@data-slot = 'popover-trigger']"));
        private By ProductPrices => By.XPath("//div[contains(@class, 'flex flex')]/div[contains(@class, 'flex')]/span"); 
        private By DropDownOptionLowToHigh => By.XPath("/html/body/div[3]/div/div/div[2]/div/div/div/div[3]");

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
            ProductsPricesList = Driver.FindElements(ProductPrices).ToList();
            return this;
        }

        public ProductsPage SelectSortOption(string option)
        {
            SortDropdown.Click();
            if (option == "Price: Low to High")
            {
                WaitForElementToAppear(DropDownOptionLowToHigh);
                Driver.FindElement(DropDownOptionLowToHigh).Click();
                ShortWaitForElementToDisappear(DropDownOptionLowToHigh);
            }
            return this;
        }

        public List<double> GetProductPrices()
        {
            return ProductsPricesList.Select(x => double.Parse(x.Text.Replace("$", ""), CultureInfo.InvariantCulture)).ToList();
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