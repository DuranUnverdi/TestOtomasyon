using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using WebDriverManager.DriverConfigs.Impl;

namespace CSharpSelFramework.tests
{
    public class Tests
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
        public void EndToEndFlow()
        {
            string[] expectedProducts = { "iphone X", "Blackberry" };
            string[] actualProducts = new string[2];
            driver.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
            driver.FindElement(By.Id("password")).SendKeys("learning");
            driver.FindElement(By.CssSelector("input[value='Sign In']")).Click();
            //driver.FindElement(By.XPath("//div[@class='form-group'][5]/label/span/input")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout")));
            IList<IWebElement> products = driver.FindElements(By.TagName("app-card"));
            foreach (IWebElement product in products)
            {
                //expectedProducts ýn içinde yer alan alanlar card da var mý 
                if (expectedProducts.Contains(product.FindElement(By.CssSelector(".card-title a")).Text))
                {
                    //click card
                    product.FindElement(By.CssSelector(".card-footer button")).Click();

                }
                TestContext.Progress.WriteLine(product.FindElement(By.CssSelector(".card-title a")).Text);

            }//sepete eklenen ürünler ile beklenen sonuç eþleþiyomu
            driver.FindElement(By.PartialLinkText("Checkout")).Click();
            IList<IWebElement> chechoutCards = driver.FindElements(By.CssSelector("h4 a"));
            for (int i = 0; i < chechoutCards.Count; i++)
            {
                actualProducts[i] = chechoutCards[i].Text;
            }
            Assert.AreEqual(expectedProducts, actualProducts);
            //chechout butonuyla alakalý iþlemler
            driver.FindElement(By.CssSelector(".btn-success")).Click();
            //inputa India seçeneðini seçiyoruz
            driver.FindElement(By.Id("country")).SendKeys("ind");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("India")));
            driver.FindElement(By.LinkText("India")).Click();
            //chechbox ý seçili hale getiriyoruz
            driver.FindElement(By.CssSelector("label[for*='checkbox2']")).Click();
            //purchase butonunu tetikliyoruz
            driver.FindElement(By.CssSelector("[value='Purchase']")).Click();
            //alerte gelen succes ya da error mesajýný yakalamam
            string confirText = driver.FindElement(By.CssSelector(".alert-success")).Text;
            StringAssert.Contains("Success", confirText);
        }
    }
}