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
            driver = new ChromeDriver(options);
            objectContainer.RegisterInstanceAs(driver);

            //go to home page
            driver.Navigate().GoToUrl("http://localhost:5213/Home/SelectContinent");
            Thread.Sleep(500);

        }

        [AfterTestRun]
        public static void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}