using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceTesting
{
    class TC05
    {
        [SetUp]
        public void Initialize()
        {
            Properties.driver = new ChromeDriver();
            Properties.driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            Console.Write("Website opened.\n");
        }

        [Test]

        public void TestCase5()
        {
            CommonMethods commonMethods = new CommonMethods();

            commonMethods.Login("standard_user", "invalidpass");
            commonMethods.VerifyErrorMessage("Epic sadface: Username and password do not match any user in this service");


        }

        [TearDown]

        public void Close()
        {
            Properties.driver.Close();
        }
    }
}
