using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;

namespace EcommerceTests.Core;

public class DriverManager
{
    private static ThreadLocal<IWebDriver> _driver = new();

    public static IWebDriver Driver => _driver.Value;

    public static void InitDriver(string browser)
    {
        if (_driver.Value != null)
            return;

        switch (browser.ToLower())
        {
            case "chrome":
                _driver.Value = new ChromeDriver();
                break;

            case "edge":
                _driver.Value = new EdgeDriver();
                break;

            default:
                throw new Exception($"Browser '{browser}' not supported");
        }


        _driver.Value.Manage().Window.Maximize();
        _driver.Value.Manage().Timeouts().ImplicitWait = new System.TimeSpan(0,0,10);
    }

    public static void QuitDriver()
    {
        _driver.Value?.Quit();
        _driver.Value = null;
    }
}