using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceTesting
{
    class CartPageObject
    {
        public CartPageObject()
        {
            PageFactory.InitElements(Properties.driver, this);
        }

        [FindsBy(How = How.Id, Using = "continue-shopping")]

        public IWebElement continueShoppingBtn { get; set; }

        [FindsBy(How = How.Id, Using = "checkout")]

        public IWebElement checkoutBtn { get; set; }
    }
}
