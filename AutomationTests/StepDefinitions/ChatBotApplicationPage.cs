using NUnit.Framework;
using OpenQA.Selenium;

namespace AutomationTests.StepDefinitions
{
    public class ChatBotApplicationPage : WebDriverHelper
    {
        private readonly IWebDriver _driver;

        private By submitButton = By.CssSelector("input[value='Submit']");
        private By continentTextBox = By.CssSelector("#Continent");
        private By categoryTextBox = By.CssSelector("#Category");
        private By locationTextBox = By.CssSelector("#Location");
        private By tempRatingTextBox = By.CssSelector("#TempRating");
        private By resultCards = By.CssSelector("[class = card-body]");
        private By FlyawayTitle = By.CssSelector("[class=fw-light]");
        private By title = By.CssSelector("html head title");
        

        public ChatBotApplicationPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }


        internal void EnterContinent(string continent)
        {
            EnterText(continentTextBox,continent);
        }

        internal void ClickSubmit()
        {
            Delay();
            Click(submitButton);
        }

        internal void PressEnter()
        {
            PressEnter(submitButton);
        }

        internal void ThePageHasChanged(string pageTitle)
        {
            Assert.AreEqual(pageTitle, title);
        }

        internal void EnterCategory(string category)
        {
            EnterText(categoryTextBox, category);
        }

        internal void EnterLocation(string location)
        {
            EnterText(locationTextBox, location);
        }

        internal void EnterTempRating(string temp)
        {
            EnterText(tempRatingTextBox, temp);
        }

    }
}