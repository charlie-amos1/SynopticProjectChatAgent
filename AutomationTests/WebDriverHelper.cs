using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTests
{
    public class WebDriverHelper
    {
        private readonly IWebDriver _driver;
        private const int SmallWait = 30;


        protected WebDriverHelper(IWebDriver driver)
        {
            _driver = driver;
        }

        protected WebDriverWait Wait(int timeInSecs)
        {
            return new WebDriverWait(_driver, TimeSpan.FromSeconds(timeInSecs));
        }

        protected IWebElement Wait(By locator, int timeInSecs)
        {
            return Wait(timeInSecs).Until(ExpectedConditions.ElementExists(locator));

        }

        protected void Delay()
        {
            Thread.Sleep(3000);
        }

        protected void Click(By locator)
        {
            Wait(locator, SmallWait);
            _driver.FindElement(locator).Click();
        }

        protected void EnterText(By locator, string text)
        {
            Delay();
            _driver.FindElement(locator).SendKeys(text);
        }

        protected string title() 
        {
            return  _driver.Title;
        }

    }
}
