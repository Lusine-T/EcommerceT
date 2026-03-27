using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

IWebDriver driver = new ChromeDriver();

//Conclusion
//The provided code snippet demonstrates a basic Selenium automation script. The script performs the following steps:

//It starts a new session with a Chrome browser.

//It navigates to the EPAM main page.

//It finds and clicks on the search icon element to activate the search functionality.

//It configures an explicit wait to wait for the search panel element to appear.

//It finds the search input element within the search panel and interacts with it using the Actions class, clicking on it and sending the keys "Automation" to simulate user input.

//It finds the find button element within the search panel and clicks on it to trigger the search process.

//The script effectively demonstrates how to automate a search action on a webpage, using various Selenium functionalities such as locating elements, clicking, sending keys, and performing explicit waits. Finally, the script closes the browser session.

try
{
    driver.Url = "https://www.epam.com";

    var searchIcon = driver.FindElement(By.ClassName("dark-iconheader-search__search-icon"));
    searchIcon.Click();

    var searchPanelWait = new WebDriverWait(driver, TimeSpan.FromSeconds(2))
    {
        PollingInterval = TimeSpan.FromSeconds(0.25),
        Message = "Search panel has not been found"
    };

    var searchPanel = searchPanelWait.Until(driver => driver.FindElement(By.ClassName("header-search__panel")));
    var searchInput = searchPanel.FindElement(By.Name("q"));

    var clickAndSendKeysActions = new Actions(driver);

    clickAndSendKeysActions.Click(searchInput)
        .Pause(TimeSpan.FromSeconds(1))
        .SendKeys("Automation")
        .Perform();

    var findButton = searchPanel.FindElement(By.XPath(".//*[@class='search-results__input-holder']/following-sibling::button"));
    findButton.Click();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
finally
{
    driver.Quit();
}
