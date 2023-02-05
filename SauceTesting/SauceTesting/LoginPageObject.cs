using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceTesting
{
    class LoginPageObject
    {
        public LoginPageObject()
        {
            PageFactory.InitElements(Properties.driver, this);
        }

        [FindsBy(How = How.Id, Using = "user-name")]

        public IWebElement usernameField { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement passwordField { get; set; }

        [FindsBy(How = How.Id, Using = "login-button")]
        public IWebElement loginButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div//h3//button[@class='error-button']")]
        public IWebElement errorMessage { get; set; }
    }
}
