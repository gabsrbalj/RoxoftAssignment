using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceTesting
{
    class CheckoutPageObject
    {
        public CheckoutPageObject()
        {
            PageFactory.InitElements(Properties.driver, this);
        }

        [FindsBy(How = How.Id, Using = "first-name")]

        public IWebElement checkoutFirstName { get; set; }

        [FindsBy(How = How.Id, Using = "last-name")]

        public IWebElement checkoutLastName { get; set; }


        [FindsBy(How = How.Id, Using = "postal-code")]

        public IWebElement checkoutPostalCode { get; set; }


        [FindsBy(How = How.Id, Using = "cancel")]

        public IWebElement cancelBtn { get; set; }

        [FindsBy(How = How.Id, Using = "continue")]

        public IWebElement continueBtn { get; set; }
    }
}
