using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumTest
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://www.google.com/");
            Thread.Sleep(2000);

            IWebElement searchInputElement = driver.FindElement(By.Name("q"));
            searchInputElement.SendKeys("What is selenium?");
            Thread.Sleep(5000);

            IWebElement searchButtonElement = driver.FindElement(By.Name("btnK"));
            searchInputElement.Click();
            Thread.Sleep(5000);

            driver.Close();

        }
    }
}
