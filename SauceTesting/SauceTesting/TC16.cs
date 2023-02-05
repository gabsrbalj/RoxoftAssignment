using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SauceTesting
{
    class TC16
    {
        [SetUp]
        public void Initialize()
        {
            Properties.driver = new ChromeDriver();
            Properties.driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            Console.Write("Website opened.\n");
        }

        [Test]

        public void TestCase16()
        {
            CommonMethods commonMethods = new CommonMethods();
            CheckoutPageObject checkoutPage = new CheckoutPageObject();
            HomePageObject homeObj = new HomePageObject();

            commonMethods.Login("standard_user", "secret_sauce");
            commonMethods.VerifyUrl("https://www.saucedemo.com/inventory.html");

            homeObj.cartIcon.Click();
            Thread.Sleep(1000);

            CartPageObject cartObj = new CartPageObject();
            cartObj.checkoutBtn.Click();
            Thread.Sleep(1000);

            commonMethods.VerifyElements(checkoutPage.checkoutFirstName);
            commonMethods.VerifyElements(checkoutPage.checkoutLastName);
            commonMethods.VerifyElements(checkoutPage.checkoutPostalCode);
            commonMethods.Verification(checkoutPage.continueBtn);
            commonMethods.Verification(checkoutPage.cancelBtn);

            Thread.Sleep(1000);
            commonMethods.Logout();


        }

        [TearDown]

        public void Close()
        {
            Properties.driver.Close();
        }
    }
}
