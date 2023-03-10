using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceTesting
{
    class TC09
    {
        [SetUp]
        public void Initialize()
        {
            Properties.driver = new ChromeDriver();
            Properties.driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            Console.Write("Website opened.\n");
        }

        [Test]

        public void TestCase9()
        {
            CommonMethods commonMethods = new CommonMethods();

            commonMethods.Login("standard_user", "secret_sauce");
            commonMethods.About();
            commonMethods.VerifyUrl("https://saucelabs.com/");
            Properties.driver.Navigate().Back();
            HomePageObject homePageObj = new HomePageObject();

            homePageObj.hamburgerCloseBtn.Click();

            commonMethods.Logout();


        }

        [TearDown]

        public void Close()
        {
            Properties.driver.Close();
        }
    }
}
