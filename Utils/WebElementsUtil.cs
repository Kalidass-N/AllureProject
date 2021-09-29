using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace AllureReportSample.Utils
{
    public class WebElementsUtil
    {
        private readonly IWebDriver _driver;
        private readonly ScenarioContext _scenarioContext;

        public WebElementsUtil(IWebDriver driver, ScenarioContext scenarioContext)
        {
            _driver = driver;
            _scenarioContext = scenarioContext;
        }

        public static string MakeScreenshot(IWebDriver driver, ScenarioContext scenarioContext)
        {
            DateTime time = DateTime.Now;
            String CurrentTime=time.ToString("hmmss tt");

            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            string fileLocation = $"C:/Users/kkalidass/source/repos/AllureProject/Screenshots/{scenarioContext.ScenarioInfo.Title}{CurrentTime}.png";
            ss.SaveAsFile(fileLocation, ScreenshotImageFormat.Png);
            return fileLocation;
        }
    }
}
