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
    class TC31
    {
        [SetUp]
        public void Initialize()
        {
            Properties.driver = new ChromeDriver();
            Properties.driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            Console.Write("Website opened.\n");
        }

        [Test]

        public void TestCase31()
        {
            CommonMethods commonMethods = new CommonMethods();
            HomePageObject homeObj = new HomePageObject();
            CartPageObject cartObj = new CartPageObject();
            CheckoutPageObject checkObj = new CheckoutPageObject();

            commonMethods.Login("problem_user", "secret_sauce");

            homeObj.cartIcon.Click();
            cartObj.checkoutBtn.Click();

            commonMethods.Checkout("Gabrijela", "Srbalj", "35254 Bebrina");

            commonMethods.VerifyElementsEmpty(checkObj.checkoutFirstName);
            commonMethods.VerifyElementsEmpty(checkObj.checkoutLastName);
            commonMethods.VerifyElementsEmpty(checkObj.checkoutPostalCode);

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
