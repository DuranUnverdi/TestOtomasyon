using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearning
{
    class SeleniumFirst
    {
        IWebDriver driver;
        [SetUp]
        public void StartBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }
        [Test]
        public void Test1()
        {
            driver.Url = "https://rahulshettyacademy.com/practice-project";
            TestContext.Progress.WriteLine(driver.Title);
            TestContext.Progress.WriteLine(driver.Url);
            //driver.Close();
            //driver.Quit();
        }
    }
}
