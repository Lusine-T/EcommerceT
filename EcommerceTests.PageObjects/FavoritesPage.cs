using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceTests.Core;
using OpenQA.Selenium;

namespace EcommerceTests.PageObjects
{
    public class FavoritesPage
    {
        private By ProductNamesLocator => By.XPath("//div[contains(@class, 'flex flex')]/a[contains(@class, 'text-lg')]");
        private List<IWebElement> Products;

        public List<string> GetProductNames()
        {
            Products = DriverManager.Driver.FindElements(ProductNamesLocator).ToList();
            List<string> productNames = new List<string>();
            foreach(IWebElement element in Products)
            {
                productNames.Add(element.Text);
            }

            return productNames;
        }
        

    }
}