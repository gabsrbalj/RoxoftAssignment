using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceTesting
{
    class TC19
    {
        [SetUp]
        public void Initialize()
        {
            Properties.driver = new ChromeDriver();
            Properties.driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            Console.Write("Website opened.\n");
        }

        [Test]

        public void TestCase19()
        {
            CommonMethods commonMethods = new CommonMethods();
            HomePageObject homeObj = new HomePageObject();
            CartPageObject cartObj = new CartPageObject();
            commonMethods.Login("standard_user", "secret_sauce");
            commonMethods.VerifyUrl("https://www.saucedemo.com/inventory.html");

            homeObj.cartIcon.Click();
            cartObj.checkoutBtn.Click();

            commonMethods.Checkout("Gabrijela", "", "35254 Bebrina");
            commonMethods.VerifyErrorMessage("Error: Last Name is required");

            commonMethods.Logout();


        }

        [TearDown]

        public void Close()
        {
            Properties.driver.Close();
        }
    }
}
