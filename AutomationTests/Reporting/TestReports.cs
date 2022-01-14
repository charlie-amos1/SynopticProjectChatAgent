using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using System;
using System.Configuration;
using System.IO;
using System.Linq;
using TechTalk.SpecFlow;

namespace AutomationTests.Reporting
{
    [Binding]
    class TestReports
    {
        private static ExtentReports _extent;
        private static ExtentTest _test;

        private readonly ScenarioContext scenarioContext;

        public TestReports (ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        [BeforeTestRun]
        public static void InstatiateReport()
        {
            string folderLocation = TestContext.CurrentContext.TestDirectory + "\\Reporting\\ChatBotReport " + DateTime.Now.ToString("dd-MM-yyy HH.mm.ss");
            Directory.CreateDirectory(folderLocation);
            var htmlReporter = new ExtentHtmlReporter(folderLocation + "\\ChatBotReport.html");
            htmlReporter.LoadConfig(TestContext.CurrentContext.TestDirectory + "\\Reporting\\extent-config.xml");

            _extent = new ExtentReports();
            _extent.AddSystemInfo("Test Environment", "<b>" + ConfigurationManager.AppSettings["HomePage"] + "</b>");
            _extent.AttachReporter(htmlReporter);
        }

        [BeforeScenario]
        public void BeforeScenario(FeatureContext featureContext)
        {
            string values = null;
            foreach (var value in scenarioContext.ScenarioInfo.Arguments.Values)
            {
                values += " (" + value.ToString() + ")";
            }

            _test = _extent.CreateTest(scenarioContext.ScenarioInfo.Title + values)
                .AssignCategory(featureContext.FeatureInfo.Title)
                .AssignCategory(featureContext.FeatureInfo.Tags)
                .CreateNode("Test Steps");
        }

        [AfterStep]
        public void AfterStep()
        {
            string stepLogText = scenarioContext.StepContext.StepInfo.StepInstance.Keyword + " " + scenarioContext.StepContext.StepInfo.Text;
            
            if (scenarioContext.StepContext.StepInfo.Table != null)
            {
                var tableRows = scenarioContext.StepContext.StepInfo.Table.Rows.SelectMany(r => r.Values).ToList();
                foreach (string row in tableRows)
                {
                    stepLogText = stepLogText + " " + row + ",";
                }               
            }

            Status stepStatus;
            if (scenarioContext.TestError == null)
            {
                stepStatus = Status.Pass;
            }
            else
            {
                stepStatus = Status.Fail;
                stepLogText = stepLogText + " : " + "<pre>" + scenarioContext.TestError.Message + "</pre>";
            }
            _test.Log(stepStatus, stepLogText);           
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            _extent.Flush();
        }
    }
}