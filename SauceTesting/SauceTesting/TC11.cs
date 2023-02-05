using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceTesting
{
    class TC11
    {
        [SetUp]
        public void Initialize()
        {
            Properties.driver = new ChromeDriver();
            Properties.driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            Console.Write("Website opened.\n");
        }

        [Test]

        public void TestCase11()
        {
            CommonMethods commonMethods = new CommonMethods();

            commonMethods.Login("standard_user", "secret_sauce");

            commonMethods.SortingItemsFromZToA();

            commonMethods.Logout();


        }

        [TearDown]

        public void Close()
        {
            Properties.driver.Close();
        }
    }
}
