using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium;
using AllureReportSample.PageClass;

namespace AllureReportSample.Steps
{
    [Binding]
    public  class LoginSteps
    {
        private readonly IWebDriver _driver;
        private readonly LoginPage loginpage;
        public LoginSteps(IWebDriver driver)
        {
            _driver = driver;
            loginpage = new LoginPage(_driver);
        }



        [Given(@"User launches pluralsight application via ""(.*)""")]
        public void GivenUserLaunchesPluralsightApplicationVia(string url)
        {
            _driver.Navigate().GoToUrl(url);
            System.Threading.Thread.Sleep(2000);
        }

        [When(@"User enters login credentials")]
        public void WhenUserEntersLoginCredentials(Table table)
        {
            loginpage.GetUsername(table.Rows[0][0]);
            System.Threading.Thread.Sleep(2000);
            loginpage.GetPassword(table.Rows[0][1]);
            System.Threading.Thread.Sleep(2000);
        }
        [Then(@"User will be navigated to the error page")]
        public void ThenUserWillBeNavigatedToTheErrorPage()
        {
            Assert.That(_driver.Url, Is.EqualTo("https://app.pluralsight.com/id"));
            System.Threading.Thread.Sleep(2000);
        }




    }
}
