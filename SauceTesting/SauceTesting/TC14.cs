using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceTesting
{
    class TC14
    {
        [SetUp]
        public void Initialize()
        {
            Properties.driver = new ChromeDriver();
            Properties.driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            Console.Write("Website opened.\n");
        }

        [Test]

        public void TestCase14()
        {
            CommonMethods commonMethods = new CommonMethods();

            commonMethods.Login("standard_user", "secret_sauce");

            HomePageObject homePageObj = new HomePageObject();

            commonMethods.Verification(homePageObj.itemName);
            commonMethods.Verification(homePageObj.itemDescription);
            commonMethods.Verification(homePageObj.itemPrice);
            commonMethods.Verification(homePageObj.itemAddToCartBtn);


            commonMethods.Logout();
        }

        [TearDown]

        public void Close()
        {
            Properties.driver.Close();
        }
    }
}
