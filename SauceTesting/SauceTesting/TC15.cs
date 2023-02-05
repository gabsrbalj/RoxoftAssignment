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
    class TC15
    {
        [SetUp]
        public void Initialize()
        {
            Properties.driver = new ChromeDriver();
            Properties.driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            Console.Write("Website opened.\n");
        }

        [Test]

        public void TestCase15()
        {
            CommonMethods commonMethods = new CommonMethods();
            DetailsPageObject detailsPage = new DetailsPageObject();

            commonMethods.Login("standard_user", "secret_sauce");

            commonMethods.SelectItemImage("item_4_img_link");

            commonMethods.Verification(detailsPage.detailsItemName);
            commonMethods.Verification(detailsPage.detailsDescription);
            commonMethods.Verification(detailsPage.detailsItemImage);
            commonMethods.Verification(detailsPage.detailsPrice);
            Thread.Sleep(1000);

            commonMethods.AddItemToCart("add-to-cart-sauce-labs-backpack");

            HomePageObject home = new HomePageObject();
            home.cartIcon.Click();

            commonMethods.CheckIfItemIsAddedToCartList("item_4_title_link");

            Thread.Sleep(1000);

            commonMethods.ShopCartIcon();
            commonMethods.VerifyBtnChangeToRemoveCart();
            commonMethods.RemoveItem("remove-sauce-labs-backpack");

            commonMethods.Logout();

        }

        [TearDown]

        public void Close()
        {
            Properties.driver.Close();
        }
    }
}
