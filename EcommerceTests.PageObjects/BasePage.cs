using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using EcommerceTests.Core;
using log4net.Repository.Hierarchy;

namespace EcommerceTests.PageObjects
{
    public abstract class BasePage
    {
        protected IWebDriver Driver;
        private readonly WebDriverWait _wait;

        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        protected IWebElement Find(By locator)
        {
            LogHelper.Info($"Finding element: {locator}");
            return _wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        protected void Click(By locator)
        {
            LogHelper.Info($"Clicking element: {locator}");
            var element = Find(locator);
            element.Click();
        }

        protected void Type(By locator, string text)
        {
            LogHelper.Info($"Typing '{text}' into: {locator}");
            var element = Find(locator);
            element.Clear();
            element.SendKeys(text);
        }

        protected string GetText(By locator)
        {
            LogHelper.Info($"Getting text from: {locator}");
            return Find(locator).Text;
        }

        protected bool IsDisplayed(By locator)
        {
            try
            {
                return Find(locator).Displayed;
            }
            catch
            {
                return false;
            }
        }

        protected void WaitForElementToDisappear(By locator)
        {
            LogHelper.Info($"Waiting for element to disappear: {locator}");
            _wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
        }

        protected void NavigateTo(string url)
        {
            LogHelper.Info($"Navigating to: {url}");
            Driver.Navigate().GoToUrl(url);
        }
    }
}