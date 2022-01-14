using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace AutomationTests.StepDefinitions
{
    public class ChatBotApplicationPage : WebDriverHelper
    {
        private readonly IWebDriver _driver;
        private readonly Actions _actions;
        private By submitButton = By.CssSelector("input[value='Submit']");
        private By continentTextBox = By.CssSelector("#Continent");
        private By categoryTextBox = By.CssSelector("#Category");
        private By locationTextBox = By.CssSelector("#Location");
        private By tempRatingTextBox = By.CssSelector("#TempRating");
        private By resultCards = By.CssSelector("[class = card-body]");
        private By FlyawayTitle = By.CssSelector("[class=fw-light]");
        private By footer = By.CssSelector(".text-muted.py-5");


        public ChatBotApplicationPage(IWebDriver driver, Actions actions) : base(driver, actions)
        {
            _driver = driver;
            _actions = actions;
        }


        internal void EnterContinent(string continent)
        {
            //MoveToElement(continentTextBox);
            Click(FlyawayTitle);
            ClickPageDown();
            ClickPageDown();
            Delay();
            EnterText(continentTextBox,continent);
        }

        internal void ClickSubmit()
        {
            //MoveToElement(footer);
            Delay();
            Click(submitButton);
        }

        internal void PressEnter()
        {
            PressEnter(submitButton);
        }

        internal void EnterCategory(string category)
        {
            //MoveToElement(categoryTextBox);
            EnterText(categoryTextBox, category);
        }

        internal void EnterLocation(string location)
        {
            //MoveToElement(locationTextBox);
            EnterText(locationTextBox, location);
        }

        internal void EnterTempRating(string temp)
        {
            //MoveToElement(tempRatingTextBox);
            EnterText(tempRatingTextBox, temp);
        }

    }
}