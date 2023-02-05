using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceTesting
{
    class CheckoutDetailsPage
    {
        public CheckoutDetailsPage()
        {
            PageFactory.InitElements(Properties.driver, this);
        }

        [FindsBy(How = How.ClassName, Using = "summary_value_label")]

        public IWebElement summaryLabel { get; set; }

        [FindsBy(How = How.ClassName, Using = "summary_tax_label")]

        public IWebElement summaryTaxLabel { get; set; }

        [FindsBy(How = How.ClassName, Using = "summary_total_label")]

        public IWebElement summaryTotalLabel { get; set; }

        [FindsBy(How = How.ClassName, Using = "summary_subtotal_label")]

        public IWebElement summarySubTotalLabel { get; set; }

        [FindsBy(How = How.Id, Using = "cancel")]

        public IWebElement cancelBtn { get; set; }

        [FindsBy(How = How.Id, Using = "finish")]

        public IWebElement finishBtn { get; set; }
    }
}
