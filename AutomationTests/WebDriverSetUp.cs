using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.Configuration;
using System.Threading;
using TechTalk.SpecFlow;

namespace AutomationTests
{
    [Binding]
    class WebDriverSetup
    {
        private static IWebDriver driver;

        [BeforeTestRun]
        public static void InstantiateDriverSetup(IObjectContainer objectContainer)
        {
            var options = new ChromeOptions();
            options.AddArgument("start-maximized");
            options.AddArguments("window-size=800, 400");
            driver = new ChromeDriver(options);
            objectContainer.RegisterInstanceAs(driver);
            ((IJavaScriptExecutor)driver).ExecuteScript("document.body.style.transform='scale(70)';");


            //go to home page
            driver.Navigate().GoToUrl("http://localhost:5213/Home/SelectContinent");
            Thread.Sleep(500);

        }

        [BeforeScenario]
        public static void BeforeScenario()
        {
            //as the search and the results page are technically the same page
            //if I refresh the screen it will take me back to the search page
            driver.Navigate().GoToUrl("http://localhost:5213/Home/SelectContinent");
            driver.Manage().Cookies.DeleteAllCookies();
        }

        [AfterTestRun]
        public static void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}