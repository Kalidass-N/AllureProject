using AllureProject.PageClass;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace AllureProject
{
    [Binding]
    public class LoginFunctionalitySteps
    {
        private readonly IWebDriver _driver;
        private readonly LoginScenarioPage lSp;

        public LoginFunctionalitySteps(IWebDriver driver)
        {
            _driver = driver;
            lSp = new LoginScenarioPage(_driver);
        }
        [Given(@"User launches pluralsight through ""(.*)""")]
        public void GivenUserLaunchesPluralsightThrough(string url)
        {
            _driver.Navigate().GoToUrl(url);
            System.Threading.Thread.Sleep(2000);
        }
        
        [When(@"customer enters the invalid login credentials '(.*)' and '(.*)'")]
        public void WhenCustomerEntersTheInvalidLoginCredentialsAnd(string user, string pass)
        {
            lSp.GetUsername(user);
            System.Threading.Thread.Sleep(2000);
            lSp.GetPassword(pass);
            System.Threading.Thread.Sleep(2000);

        }
        
        [Then(@"User should be redirected to the error page")]
        public void ThenUserShouldBeRedirectedToTheErrorPage()
        {
            Assert.That(_driver.Title,Is.EqualTo("Sign In | Pluralsight"));
        }
    }
}
