using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllureProject.PageClass
{
    public class LoginScenarioPage
    {
        private IWebDriver _driver;

        public LoginScenarioPage(IWebDriver driver)
        {
            _driver = driver;
        }
        private IWebElement Username => _driver.FindElement(By.Id("Username"));
        private IWebElement Password => _driver.FindElement(By.Id("Password"));

        public void GetUsername(string name)
        {
            Username.SendKeys(name);
        }
        public void GetPassword(string pass)
        {
            Password.SendKeys(pass);
        }
    }
}
