using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace AutomationTests.StepDefinitions
{
    [Binding]
    public class ChatBotFeatureStepDefinitions
    {
        public readonly ChatBotApplicationPage _page;
        protected readonly IWebDriver _driver;

        public ChatBotFeatureStepDefinitions(IWebDriver driver, ChatBotApplicationPage page) 
        {
            _driver = driver;
            _page = page;
        }


        [Given(@"I enter '([^']*)' in the select continent page")]
        public void GivenIEnterInTheSelectContinentPage(string continent)
        {
            _page.EnterContinent(continent);
        }

        [When(@"I click submit")]
        public void WhenIClickSubmit()
        {
            _page.ClickSubmit(); ;
        }

        [Then(@"I should be taken to the '([^']*)' page")]
        public void ThenIShouldBeTakenToThePage(string pageTitle)
        {
            _page.ThePageHasChanged(pageTitle);
        }


        [When(@"I enter '([^']*)' in the select catergory page")]
        public void WhenIEnterInTheSelectCatergoryPage(string active)
        {
            _page.EnterCategory(active);
        }

        [When(@"I enter '([^']*)' in the select location page")]
        public void WhenIEnterInTheSelectLocationPage(string sea)
        {
            _page.EnterLocation(sea);
        }

        [When(@"I enter '([^']*)' in the select Temperature Rating page")]
        public void WhenIEnterInTheSelectTemperatureRatingPage(string mild)
        {
            _page.EnterTempRating(mild);
        }


    }
}