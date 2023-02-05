using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceTesting
{
    class TC01
    {
        [SetUp]
        public void Initialize()
        {
            Properties.driver = new ChromeDriver();
            Properties.driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            Console.Write("Website opened.\n");
        }

        [Test]

        public void TestCase1()
        {
            CommonMethods commonMethods = new CommonMethods();
            LoginPageObject loginPageObj = new LoginPageObject();

            commonMethods.VerifyElements(loginPageObj.usernameField);
            commonMethods.VerifyElements(loginPageObj.passwordField);
            commonMethods.Verification(loginPageObj.loginButton);

            commonMethods.VerifyUrl("https://www.saucedemo.com/");
        }

        [TearDown]

        public void Close()
        {
            Properties.driver.Close();
        }
    }
}
