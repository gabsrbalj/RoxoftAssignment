using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceTesting
{
    class DetailsPageObject
    {
        public DetailsPageObject()
        {
            PageFactory.InitElements(Properties.driver, this);
        }

        [FindsBy(How = How.ClassName, Using = "inventory_details_img")]

        public IWebElement detailsItemImage { get; set; }


        [FindsBy(How = How.XPath, Using = "//div[@class='inventory_details_name large_size']")]

        public IWebElement detailsItemName { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='inventory_details_desc large_size']")]

        public IWebElement detailsDescription { get; set; }


        [FindsBy(How = How.ClassName, Using = "inventory_details_price")]

        public IWebElement detailsPrice { get; set; }
    }
}
