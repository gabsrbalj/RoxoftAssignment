using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceTesting
{
    class TC04
    {
        [SetUp]
        public void Initialize()
        {
            Properties.driver = new ChromeDriver();
            Properties.driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            Console.Write("Website opened.\n");
        }

        [Test]

        public void TestCase4()
        {
            CommonMethods commonMethods = new CommonMethods();

            commonMethods.Login("standard_user", "");
            commonMethods.VerifyErrorMessage("Epic sadface: Password is required");


        }

        [TearDown]

        public void Close()
        {
            Properties.driver.Close();
        }
    }
}
