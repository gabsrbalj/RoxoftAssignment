using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceTesting
{
    class TC22
    {
        [SetUp]
        public void Initialize()
        {
            Properties.driver = new ChromeDriver();
            Properties.driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            Console.Write("Website opened.\n");
        }

        [Test]

        public void TestCase22()
        {
            CommonMethods commonMethods = new CommonMethods();

            commonMethods.Login("locked_out_user", "secret_sauce");

            commonMethods.VerifyErrorMessage("Epic sadface: Sorry, this user has been locked out.");
        }

        [TearDown]

        public void Close()
        {
            Properties.driver.Close();
        }
    }
}
