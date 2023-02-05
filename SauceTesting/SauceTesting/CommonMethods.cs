using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SauceTesting
{
    class CommonMethods
    {
        LoginPageObject loginPage = new LoginPageObject();
        HomePageObject homePage = new HomePageObject();

        public void VerifyElements(IWebElement element)
        {
            bool elementDisplayed = element.Displayed;
            bool elementEnabled = element.Enabled;
            string elementEmpty = element.GetAttribute("value");

            Assert.IsTrue(elementDisplayed, "Element is not displayed");
            Assert.IsTrue(elementEnabled, "Element is not enabled");
            Assert.IsEmpty(elementEmpty, "Element is not empty");
        }

        public void VerifyElementsEmpty(IWebElement element)
        {
            bool elementDisplayed = element.Displayed;
            bool elementEnabled = element.Enabled;
            string elementEmpty = element.GetAttribute("value");

            Assert.IsTrue(elementDisplayed, "Element should not be empty!");
            Assert.IsTrue(elementEnabled, "Element should not be empty!");
            Assert.IsNotEmpty(elementEmpty, "Element hould not be empty!");
        }
        public void Verification(IWebElement element)
        {
            bool elDisplayed = element.Displayed;
            bool elEnabled = element.Enabled;

            Assert.IsTrue(elDisplayed, "Element is not displayed");
            Assert.IsTrue(elEnabled, "Element is not enabled");
        }
        public void VerifyUrl(string expectedUrl)
        {
            string actualUrl = Properties.driver.Url;
            Assert.AreEqual(expectedUrl, actualUrl, "URLs are not equal");
        }

        public void Login(string username, string password)
        {
            loginPage.usernameField.SendKeys(username);
            loginPage.passwordField.SendKeys(password);
            Thread.Sleep(2000);
            loginPage.loginButton.Click();

        }

        public void VerifyErrorMessage(string expectedErrorMessage)
        {
            bool isErrorDisplayed = loginPage.errorMessage.Displayed;
            string actualErrorMessage = Properties.driver.FindElement(By.XPath("//*[@data-test='error']")).Text;
            Assert.IsTrue(isErrorDisplayed, "Error message not displayed");
            Assert.AreEqual(expectedErrorMessage, actualErrorMessage);
        }

        public void Logout()
        {
            homePage.hamburgerIconButton.Click();
            Thread.Sleep(1000);
            homePage.hamburgerOptionLogout.Click();
        }

        public void AllItems()
        {
            homePage.hamburgerIconButton.Click();
            Thread.Sleep(1000);
            homePage.hamburgerOptionAllItems.Click();
            homePage.hamburgerCloseBtn.Click();
        }

        public void About()
        {
            homePage.hamburgerIconButton.Click();
            Thread.Sleep(1000);
            homePage.hamburgerOptionAbout.Click();
            Thread.Sleep(1000);
            string expectedUrl = "https://saucelabs.com/";
            Assert.IsTrue(Properties.driver.Url == "https://saucelabs.com/", "Actual and expected url are not the same");
        }

        public void ResetAppState()
        {
            homePage.hamburgerIconButton.Click();
            Thread.Sleep(1000);
            homePage.hamburgerOptionResetAppState.Click();
            homePage.hamburgerCloseBtn.Click();
        }

        public void SortingItemsFromAToZ()
        {
            SelectElement dropdown = new SelectElement(Properties.driver.FindElement(By.ClassName("product_sort_container")));
            dropdown.SelectByText("Name (A to Z)");

            IList<IWebElement> itemNameList = Properties.driver.FindElements(By.ClassName("inventory_item_name"));
            List<string> itemListOfStrings = new List<string>();

            for (int i = 0; i < itemNameList.Count; i++)
            {
                itemListOfStrings.Add(itemNameList[i].Text);
            }

            for (int i = 1; i < itemListOfStrings.Count; i++)
            {

                List<int> stringComparisonList = new List<int>();
                stringComparisonList.Add(itemListOfStrings[i].CompareTo(itemListOfStrings[i - 1]));
                bool a = true;
                foreach (int n in stringComparisonList)
                {
                    if (n == 1)
                    {
                        Assert.IsTrue(a, "Strings are not ordered alphabetically");
                    }
                    else
                    {
                        a = false;
                        Assert.IsTrue(a, "Strings are not ordered alphabetically");
                    }
                }

            }
        }

        public void SortingItemsFromZToA()
        {

            SelectElement dropdown = new SelectElement(Properties.driver.FindElement(By.ClassName("product_sort_container")));
            dropdown.SelectByText("Name (Z to A)");

            IList<IWebElement> itemNameList = Properties.driver.FindElements(By.ClassName("inventory_item_name"));
            List<string> itemListOfStrings = new List<string>();

            for (int i = 0; i < itemNameList.Count; i++)
            {
                itemListOfStrings.Add(itemNameList[i].Text);
            }

            for (int i = 1; i < itemListOfStrings.Count; i++)
            {

                List<int> stringComparisonList = new List<int>();
                stringComparisonList.Add(itemListOfStrings[i].CompareTo(itemListOfStrings[i - 1]));
                bool a = true;
                foreach (int n in stringComparisonList)
                {
                    if (n == -1)
                    {
                        Assert.IsTrue(a, "Strings are not ordered from Z to A");
                    }
                    else
                    {
                        a = false;
                        Assert.IsTrue(a, "Strings are not ordered from Z to A");
                    }
                }
            }
        }

        public void SortByPriceHighToLow()
        {
            IList<IWebElement> listBefore = Properties.driver.FindElements(By.ClassName("inventory_item_price"));
            List<string> valuesBefore = new List<string>();
            List<double> doubleList = new List<double>();
            for (int i = 0; i < listBefore.Count; i++)
            {
                valuesBefore.Add(listBefore[i].Text);
            }

            for (int i = 0; i < valuesBefore.Count; i++)
            {
                valuesBefore[i] = valuesBefore[i].Replace("$", "");
                double d = double.Parse(valuesBefore[i]);
                doubleList.Add(d);
            }

            SelectElement dropdown = new SelectElement(Properties.driver.FindElement(By.ClassName("product_sort_container")));
            dropdown.SelectByText("Price (high to low)");

            IList<IWebElement> listAfter = Properties.driver.FindElements(By.ClassName("inventory_item_price"));
            List<string> valuesAfter = new List<string>();
            List<double> doubleListAfter = new List<double>();

            for (int i = 0; i < listAfter.Count; i++)
            {
                valuesAfter.Add(listAfter[i].Text);
            }

            for (int i = 0; i < valuesAfter.Count; i++)
            {
                valuesAfter[i] = valuesAfter[i].Replace("$", "");
                double e = double.Parse(valuesAfter[i]);
                doubleListAfter.Add(e);
            }

            doubleList.Sort();
            List<double> reverse = Enumerable.Reverse(doubleList).ToList();

            Assert.AreEqual(reverse, doubleListAfter, "Items are not sorted correctly");
        }

        public void SortByPriceLowToHigh()
        {
            IList<IWebElement> listBefore = Properties.driver.FindElements(By.ClassName("inventory_item_price"));
            List<string> valuesBefore = new List<string>();
            List<double> doubleList = new List<double>();
            for (int i = 0; i < listBefore.Count; i++)
            {
                valuesBefore.Add(listBefore[i].Text);
            }

            for (int i = 0; i < valuesBefore.Count; i++)
            {
                valuesBefore[i] = valuesBefore[i].Replace("$", "");
                double d = double.Parse(valuesBefore[i]);
                doubleList.Add(d);
            }

            SelectElement dropdown = new SelectElement(Properties.driver.FindElement(By.ClassName("product_sort_container")));
            dropdown.SelectByText("Price (low to high)");

            IList<IWebElement> listAfter = Properties.driver.FindElements(By.ClassName("inventory_item_price"));
            List<string> valuesAfter = new List<string>();
            List<double> doubleListAfter = new List<double>();

            for (int i = 0; i < listAfter.Count; i++)
            {
                valuesAfter.Add(listAfter[i].Text);
            }

            for (int i = 0; i < valuesAfter.Count; i++)
            {
                valuesAfter[i] = valuesAfter[i].Replace("$", "");
                double e = double.Parse(valuesAfter[i]);
                doubleListAfter.Add(e);
            }

            doubleList.Sort();


            Assert.AreEqual(doubleList, doubleListAfter, "Items are not sorted correctly");
        }
    }
}
