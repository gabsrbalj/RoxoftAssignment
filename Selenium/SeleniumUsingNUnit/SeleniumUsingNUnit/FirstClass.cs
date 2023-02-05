using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumUsingNUnit
{
    public class FirstClass
    {
        IWebDriver driver = new ChromeDriver();

        //sintaksa NUnit test metode public void methodName()

        // otvaranje browsera 
        [SetUp]
        public void Initialize()
        {

            driver.Navigate().GoToUrl("https://www.facebook.com/");
            driver.Manage().Window.Maximize();
            Thread.Sleep(2000);

        }

        [Test]
        public void ExecuteTest()
        {

            IWebElement emailInputElement = driver.FindElement(By.Id("email"));
            emailInputElement.SendKeys("gabrijela.srbalj@gmail.com");
            Thread.Sleep(2000);
            Console.Write("Email/Username is entered.\n");

            IWebElement passwordInputElement = driver.FindElement(By.Id("pass"));
            passwordInputElement.SendKeys("loopitera300599");
            Thread.Sleep(2000);
            Console.Write("Password is entered.");

            IWebElement loginButtonElement = driver.FindElement(By.XPath("//button[@name='login']"));
            loginButtonElement.Click();
            Thread.Sleep(2000);
            Console.Write("Login button clicked.");

        }

        [TearDown]
        public void EndTest()
        {
            driver.Close();
        }

        static void Main(string[] args)
        {
            FirstClass classObj = new FirstClass();
            classObj.Initialize();
            classObj.ExecuteTest();
            classObj.EndTest();
        }

    }
}
