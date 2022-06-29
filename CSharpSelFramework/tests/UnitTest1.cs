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
                //expectedProducts �n i�inde yer alan alanlar card da var m� 
                if (expectedProducts.Contains(product.FindElement(By.CssSelector(".card-title a")).Text))
                {
                    //click card
                    product.FindElement(By.CssSelector(".card-footer button")).Click();

                }
                TestContext.Progress.WriteLine(product.FindElement(By.CssSelector(".card-title a")).Text);

            }//sepete eklenen �r�nler ile beklenen sonu� e�le�iyomu
            driver.FindElement(By.PartialLinkText("Checkout")).Click();
            IList<IWebElement> chechoutCards = driver.FindElements(By.CssSelector("h4 a"));
            for (int i = 0; i < chechoutCards.Count; i++)
            {
                actualProducts[i] = chechoutCards[i].Text;
            }
            Assert.AreEqual(expectedProducts, actualProducts);
            //chechout butonuyla alakal� i�lemler
            driver.FindElement(By.CssSelector(".btn-success")).Click();
            //inputa India se�ene�ini se�iyoruz
            driver.FindElement(By.Id("country")).SendKeys("ind");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("India")));
            driver.FindElement(By.LinkText("India")).Click();
            //chechbox � se�ili hale getiriyoruz
            driver.FindElement(By.CssSelector("label[for*='checkbox2']")).Click();
            //purchase butonunu tetikliyoruz
            driver.FindElement(By.CssSelector("[value='Purchase']")).Click();
            //alerte gelen succes ya da error mesaj�n� yakalamam
            string confirText = driver.FindElement(By.CssSelector(".alert-success")).Text;
            StringAssert.Contains("Success", confirText);
        }
    }
}