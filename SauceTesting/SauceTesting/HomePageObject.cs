using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceTesting
{
    class HomePageObject
    {
        public HomePageObject()
        {
            PageFactory.InitElements(Properties.driver, this);
        }

        [FindsBy(How = How.Id, Using = "react-burger-menu-btn")]

        public IWebElement hamburgerIconButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//nav/a[@id='logout_sidebar_link']")]
        public IWebElement hamburgerOptionLogout { get; set; }

        [FindsBy(How = How.XPath, Using = "//nav/a[@id='about_sidebar_link']")]
        public IWebElement hamburgerOptionAbout { get; set; }

        [FindsBy(How = How.XPath, Using = "//nav/a[@id='inventory_sidebar_link']")]
        public IWebElement hamburgerOptionAllItems { get; set; }

        [FindsBy(How = How.XPath, Using = "//nav/a[@id='reset_sidebar_link']")]
        public IWebElement hamburgerOptionResetAppState { get; set; }


        [FindsBy(How = How.Id, Using = "react-burger-cross-btn")]
        public IWebElement hamburgerCloseBtn { get; set; }

        [FindsBy(How = How.ClassName, Using = "inventory_item_name")]
        public IWebElement itemName { get; set; }

        [FindsBy(How = How.ClassName, Using = "inventory_item_desc")]
        public IWebElement itemDescription { get; set; }

        [FindsBy(How = How.ClassName, Using = "inventory_item_price")]
        public IWebElement itemPrice { get; set; }

        [FindsBy(How = How.Id, Using = "add-to-cart-sauce-labs-backpack")]
        public IWebElement itemAddToCartBtn { get; set; }

        [FindsBy(How = How.ClassName, Using = "shopping_cart_link")]
        public IWebElement cartIcon { get; set; }
    }
}
