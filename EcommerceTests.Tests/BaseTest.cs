using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EcommerceTests.Core;

namespace EcommerceTests.Tests;

public class BaseTest : IDisposable
{
    protected void Setup(string browser)
    {
        LogHelper.Info($"Initializing browser: {browser}");
        DriverManager.InitDriver(browser);
        DriverManager.Driver.Navigate().GoToUrl(Config.BaseUrl);
    }

    protected void TearDown()
    {
        LogHelper.Info("Closing browser");
        DriverManager.QuitDriver();
    }

    public void Dispose()
    {
        TearDown();
    }
}
