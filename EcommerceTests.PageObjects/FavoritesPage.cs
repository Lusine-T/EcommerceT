using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace EcommerceTests.PageObjects
{
    public class FavoritesPage
    {
        private By ProductNames => By.XPath("//div[contains(@class, 'flex flex')]/a[contains(@class, 'text-lg')]");

        public ProductsPage GetProductNames()
        {
            ProductsNamesList = Driver.FindElements(ProductNames).ToList();
            
            return this;
        }


    }
}
