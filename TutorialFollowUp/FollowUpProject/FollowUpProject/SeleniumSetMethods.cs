using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FollowUpProject
{
    class SeleniumSetMethods
    {
        // brisemo el. type i text el iz def funkcije jer dolazi iz  page object modela
        // unesi tekst metoda

        //public static void EnterText(string textElement,string value, PropertyType elementType)
        //{
        //    if (elementType == PropertyType.Id)
        //    {
        //        PropertiesCollection.driver.FindElement(By.Id(textElement)).SendKeys(value);
        //    }

        //    if(elementType == PropertyType.Name)
        //    {
        //        PropertiesCollection.driver.FindElement(By.Name(textElement)).SendKeys(value);
        //    }
        //}

        //extended methos (use this) 
        public static void EnterText(IWebElement element, string value)
        {
            element.SendKeys(value);
        }

        //klik metoda 
        public static void ClickOn(IWebElement element)
        {
            element.Click();
        }

        public static void SelectDropDown(IWebElement element, string value)
        {
            new SelectElement(element).SelectByText(value);
        }
    }
}
