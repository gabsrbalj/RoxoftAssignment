﻿using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceTesting
{
    class TC24
    {
        [SetUp]
        public void Initialize()
        {
            Properties.driver = new ChromeDriver();
            Properties.driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            Console.Write("Website opened.\n");
        }

        [Test]

        public void TestCase24()
        {
            CommonMethods commonMethods = new CommonMethods();

            commonMethods.Login("problem_user", "secret_sauce");

            commonMethods.About();
            Properties.driver.Navigate().Back();

            commonMethods.Logout();
        }

        [TearDown]

        public void Close()
        {
            Properties.driver.Close();
        }
    }
}
