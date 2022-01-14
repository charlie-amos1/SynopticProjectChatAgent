using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
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
        Actions _actions;

        public WebDriverHelper(IWebDriver driver ,Actions actions)
        {
            _driver = driver;
           _actions= actions;
        }

        protected WebDriverWait Wait(int timeInSecs)
        {
            return new WebDriverWait(_driver, TimeSpan.FromSeconds(timeInSecs));
        }

        protected IWebElement Wait(By locator, int timeInSecs)
        {
            return Wait(timeInSecs).Until(ExpectedConditions.ElementExists(locator));

        }

        protected void MoveToElement(By element) 
        {
            _actions.MoveToElement(_driver.FindElement(element)).Perform();
        }

        protected void PressEnter(By element) 
        {
            _driver.FindElement(element).SendKeys(Keys.Enter);
        }

        protected void Delay()
        {
            Thread.Sleep(2000);
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

        public string title() 
        {
            return _driver.Title;
        }

    }
}
