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
    class TC20
    {
        [SetUp]
        public void Initialize()
        {
            Properties.driver = new ChromeDriver();
            Properties.driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            Console.Write("Website opened.\n");
        }

        [Test]

        public void TestCase20()
        {
            CommonMethods commonMethods = new CommonMethods();
            HomePageObject homeObj = new HomePageObject();
            CartPageObject cartObj = new CartPageObject();
            CheckoutDetailsPage chDetails = new CheckoutDetailsPage();

            commonMethods.Login("standard_user", "secret_sauce");
            commonMethods.VerifyUrl("https://www.saucedemo.com/inventory.html");

            commonMethods.AddItemToCart("add-to-cart-sauce-labs-backpack");
            homeObj.cartIcon.Click();
            Thread.Sleep(1000);

            List<string> itemList = commonMethods.ListOfItems();
            cartObj.checkoutBtn.Click();

            commonMethods.Checkout("Gabrijela", "Srbalj", "35254 Bebrina");
            Thread.Sleep(1000);

            List<string> checkoutItemList = commonMethods.ListOfItems();

            Assert.AreEqual(itemList, checkoutItemList);

            commonMethods.Verification(chDetails.summaryLabel);
            commonMethods.Verification(chDetails.summaryTaxLabel);
            commonMethods.Verification(chDetails.summaryTotalLabel);

            commonMethods.CheckPriceCalculation();

            chDetails.finishBtn.Click();

            commonMethods.Logout();


        }

        [TearDown]

        public void Close()
        {
            Properties.driver.Close();
        }
    }
}
