using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SauceTesting
{
    class CommonMethods
    {
        LoginPageObject loginPage = new LoginPageObject();
        HomePageObject homePage = new HomePageObject();

        public void VerifyElements(IWebElement element)
        {
            bool elementDisplayed = element.Displayed;
            bool elementEnabled = element.Enabled;
            string elementEmpty = element.GetAttribute("value");

            Assert.IsTrue(elementDisplayed, "Element is not displayed");
            Assert.IsTrue(elementEnabled, "Element is not enabled");
            Assert.IsEmpty(elementEmpty, "Element is not empty");
        }

        public void VerifyElementsEmpty(IWebElement element)
        {
            bool elementDisplayed = element.Displayed;
            bool elementEnabled = element.Enabled;
            string elementEmpty = element.GetAttribute("value");

            Assert.IsTrue(elementDisplayed, "Element should not be empty!");
            Assert.IsTrue(elementEnabled, "Element should not be empty!");
            Assert.IsNotEmpty(elementEmpty, "Element hould not be empty!");
        }
        public void Verification(IWebElement element)
        {
            bool elDisplayed = element.Displayed;
            bool elEnabled = element.Enabled;

            Assert.IsTrue(elDisplayed, "Element is not displayed");
            Assert.IsTrue(elEnabled, "Element is not enabled");
        }
        public void VerifyUrl(string expectedUrl)
        {
            string actualUrl = Properties.driver.Url;
            Assert.AreEqual(expectedUrl, actualUrl, "URLs are not equal");
        }

        public void Login(string username, string password)
        {
            loginPage.usernameField.SendKeys(username);
            loginPage.passwordField.SendKeys(password);
            Thread.Sleep(2000);
            loginPage.loginButton.Click();

        }

        public void VerifyErrorMessage(string expectedErrorMessage)
        {
            bool isErrorDisplayed = loginPage.errorMessage.Displayed;
            string actualErrorMessage = Properties.driver.FindElement(By.XPath("//*[@data-test='error']")).Text;
            Assert.IsTrue(isErrorDisplayed, "Error message not displayed");
            Assert.AreEqual(expectedErrorMessage, actualErrorMessage);
        }

        public void Logout()
        {
            homePage.hamburgerIconButton.Click();
            Thread.Sleep(1000);
            homePage.hamburgerOptionLogout.Click();
        }

        public void AllItems()
        {
            homePage.hamburgerIconButton.Click();
            Thread.Sleep(1000);
            homePage.hamburgerOptionAllItems.Click();
            homePage.hamburgerCloseBtn.Click();
        }
    }
}
