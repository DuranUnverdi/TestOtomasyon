using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearning
{
    public class Locators
    {
        IWebDriver driver;
        [SetUp]
        public void StartBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
        }
        [Test]
        public void LocatorsIdentification()
        {
            driver.FindElement(By.Id("username")).SendKeys("rahulshettacademy");
            driver.FindElement(By.Id("username")).Clear();
            driver.FindElement(By.Id("username")).SendKeys("rahulshety");
            driver.FindElement(By.Id("password")).SendKeys("1231231");
            //css selector
            driver.FindElement(By.CssSelector("input[value='Sign In']")).Click();
            //driver.FindElement(By.XPath("//input[@value='Sign In']")).Click(); diğer bi butonu click yapma işlemide budur
            //Thread.Sleep(3000);
            String errorMessage = driver.FindElement(By.ClassName("alert-danger")).Text;
            TestContext.Progress.WriteLine(errorMessage);
            driver.FindElement(By.XPath("//div[@class='form-group'][5]/label/span/input")).Click();
        }
    }
}
