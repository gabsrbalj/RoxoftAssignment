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
    class TC29
    {
        [SetUp]
        public void Initialize()
        {
            Properties.driver = new ChromeDriver();
            Properties.driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            Console.Write("Website opened.\n");
        }

        [Test]

        public void TestCase29()
        {
            CommonMethods commonMethods = new CommonMethods();

            commonMethods.Login("problem_user", "secret_sauce");

            commonMethods.AddItemToCart("add-to-cart-sauce-labs-backpack");
            commonMethods.AddItemToCart("add-to-cart-sauce-labs-bike-light");
            commonMethods.AddItemToCart("add-to-cart-sauce-labs-bolt-t-shirt");
            commonMethods.AddItemToCart("add-to-cart-sauce-labs-fleece-jacket");
            commonMethods.AddItemToCart("add-to-cart-sauce-labs-onesie");
            commonMethods.AddItemToCart("add-to-cart-test.allthethings()-t-shirt-(red)");

            commonMethods.CheckIfItemIsAddedToCartList("item_5_title_link");
            commonMethods.CheckIfItemIsAddedToCartList("item_4_title_link");
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
