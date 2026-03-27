using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceTests.Core;
using log4net.Repository.Hierarchy;
using OpenQA.Selenium;

namespace EcommerceTests.PageObjects
{
    public class LoginPage : BasePage
    {
        public LoginPage() : base(DriverManager.Driver) { }

        private IWebElement EmailField => Driver.FindElement(By.XPath("//input[@id='email']"));
        private IWebElement PasswordField => Driver.FindElement(By.XPath("//input[@id='password']"));
        private IWebElement LoginButton => Driver.FindElement(By.XPath("//button[@type='submit']"));
        
        private IWebElement UsernameError;
        private IWebElement PasswordError;
        
        public LoginPage EnterEmail(string email)
        {
            EmailField.Clear();
            EmailField.SendKeys(email);
            LogHelper.Info($"Entered email: {email}");
            return this;
        }
       
        public LoginPage EnterPassword(string password)
        {
            PasswordField.Clear();
            PasswordField.SendKeys(password);
            LogHelper.Info($"Entered password: {password}");
            return this;
        }

        public LoginPage ClickLogin()
        {
            LoginButton.Click();
            LogHelper.Info("Clicked Login button");
            return this;
        }

        public void InitializeUsernameError()
        {
            try
            {
                this.UsernameError = Driver.FindElement(By.XPath("//input[@id='email']/parent::div/following-sibling::p"));
            }
            catch (Exception ex)
            {
                LogHelper.Info($"Cannot initialize UsernameError field");
            }
        }
        public void InitializePasswordError()
        {
            try
            {
                this.PasswordError = Driver.FindElement(By.XPath("//input[@id='password']/parent::div/following-sibling::p"));
            }
            catch (Exception ex)
            {
                LogHelper.Info($"Cannot initialize PasswordError field");
            }
        }


        public ProductsPage Login(string email, string password)
        {
            LogHelper.Info($"Login with email: {email}");

            EmailField.SendKeys(email);
            PasswordField.SendKeys(password);
            LoginButton.Click();
            return new ProductsPage();
        }

        public string GetUsernameError()
        {
            if (UsernameError is not null && UsernameError.Displayed)
                return UsernameError.Text;
             
            return string.Empty;
        }
        public string GetPasswordError()
        {
            if (PasswordError is not null && PasswordError.Displayed)
                return PasswordError.Text;

            return string.Empty;
        }
    }
}