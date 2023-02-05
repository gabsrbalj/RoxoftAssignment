using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FollowUpProject
{
    class Program
    {

        [SetUp]
        public void Initialize()
        {
            PropertiesCollection.driver = new ChromeDriver();
            PropertiesCollection.driver.Navigate().GoToUrl("https://demosite.executeautomation.com/");
            Console.Write("Website opened.");
        }

        [Test]
        public void ExecuteTest()
        {
            // login to app
            LoginPageObject pageLogin = new LoginPageObject();
            EAPageObject pageEA = new EAPageObject();

            pageLogin.Login("someusername", "somepassword");

            pageEA.FillUserForm("gs", "Gabi", "Gabrijela");
            // initializing page calling its reference

            Thread.Sleep(1000);


        }

        [TearDown]

        public void EndTest()
        {
            PropertiesCollection.driver.Close();
        }
    }
}
