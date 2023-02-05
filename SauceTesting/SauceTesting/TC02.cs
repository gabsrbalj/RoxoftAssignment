using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceTesting
{
    class TC02
    {
        [SetUp]
        public void Initialize()
        {
            Properties.driver = new ChromeDriver();
            Properties.driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            Console.Write("Website opened.\n");
        }

        [Test]

        public void TestCase2()
        {
            CommonMethods commonMethods = new CommonMethods();

            commonMethods.Login("", "");
            commonMethods.VerifyErrorMessage("Epic sadface: Username is required");


        }

        [TearDown]

        public void Close()
        {
            Properties.driver.Close();
        }
    }
}
