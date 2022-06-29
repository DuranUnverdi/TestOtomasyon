using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearning
{
    public class WindowHandles
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
        public void WindowHandle()
        {
            //linke tıklandıktan sonra başka sayfaya yönlendirip tıklananan sayfada durmasını sağlıyoruz
           
            String email="mentor@rahulshettyacademy.com";
            String parentWindId = driver.CurrentWindowHandle;
            driver.FindElement(By.ClassName("blinkingText")).Click();
            Assert.AreEqual(2, driver.WindowHandles.Count);
            String childWindow = driver.WindowHandles[1];
            driver.SwitchTo().Window(childWindow);
            TestContext.Progress.WriteLine(driver.FindElement(By.CssSelector(".red")).Text);
           String text= driver.FindElement(By.CssSelector(".red")).Text;

            //email de ki kısmı kırımızı yazan metinden alıyo boşluğa kadar alıp login sayfasına mailini yazdırdı
            String[] splittedText = text.Split("at");
            String[] trimmedString = splittedText[1].Trim().Split(" ");
            Assert.AreEqual(email, trimmedString[0]);
            driver.SwitchTo().Window(parentWindId);
            driver.FindElement(By.Id("username")).SendKeys(trimmedString[0]);
        }
    }
}
