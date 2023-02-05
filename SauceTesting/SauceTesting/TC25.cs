using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SauceTesting
{
    class TC25
    {
        [SetUp]
        public void Initialize()
        {
            Properties.driver = new ChromeDriver();
            Properties.driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            Console.Write("Website opened.\n");
        }

        [Test]

        public void TestCase25()
        {
            CommonMethods commonMethods = new CommonMethods();

            commonMethods.Login("problem_user", "secret_sauce");

            commonMethods.SortingItemsFromAToZ();
            Thread.Sleep(2000);

            commonMethods.Logout();
        }

        [TearDown]

        public void Close()
        {
            Properties.driver.Close();
        }
    }
}
