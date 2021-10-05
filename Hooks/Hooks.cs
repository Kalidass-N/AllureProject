using Allure.Commons;
using AllureReportSample.Utils;
using BoDi;
//using NLog;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;

namespace AllureReportSample.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        private SpecFlowOutputHelper _specFlowOutputHelper;
        private readonly IObjectContainer objectContainer;
        //private readonly Driver _driver;
        public IWebDriver driver;
        private readonly AllureLifecycle _allureLifecycle;

        private readonly ScenarioContext _scenarioContext;
        
        

        public Hooks( ScenarioContext scenarioContext, IObjectContainer container, SpecFlowOutputHelper specFlowOutputHelper)
        {
            objectContainer = container;
            _scenarioContext = scenarioContext;
            _allureLifecycle = AllureLifecycle.Instance;
            _specFlowOutputHelper = specFlowOutputHelper;
        }
        [OneTimeSetUp]
        public void SetUpAllure()
        {
            Environment.CurrentDirectory = Path.GetDirectoryName(GetType().Assembly.Location);
        }

        [BeforeScenario]
        public void SetUp()
        {
           if(_scenarioContext.ScenarioInfo.Tags[0]=="chrome")
            {
                //Logger.Info("Webdriver Initializatuion, Chrome");
                driver = new ChromeDriver();
                objectContainer.RegisterInstanceAs(driver);
                _specFlowOutputHelper.WriteLine("Webdriver Initializatuion, Chrome ");
                //driver.Navigate().GoToUrl("https://wikipedia.com");
            }
        }

        [AfterScenario]
        public void TearDown()
        {
            var location=WebElementsUtil.MakeScreenshot(driver, _scenarioContext);
            _specFlowOutputHelper.AddAttachment(location);
            //if (_scenarioContext.TestError != null)
            //{
            //    var Path = WebElementsUtil.MakeScreenshot(driver);
            //    _allureLifecycle.AddAttachment(Path);
            //}
            //else
            //{
            //    var error = _scenarioContext.TestError;
            //    Console.WriteLine("An error ocurred:" + error.Message);
            //    Console.WriteLine("It was of type:" + error.GetType().Name);
            //}
            driver.Quit();
            //AllureHackForScenarioOutlineTests();
        }
       
    }
}
