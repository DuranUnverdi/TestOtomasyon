using CSharpSelFramework.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearning
{
  public class E2ETest:Base
    {
 
        [Test]
        public void EndToEndFlow()
        {
            String[] expectedProducts = { "iphone X", "Blackberry"};
            String[] actualProducts = new String[2];
            driver.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
            driver.FindElement(By.Id("password")).SendKeys("learning");
            driver.FindElement(By.CssSelector("input[value='Sign In']")).Click();
            //driver.FindElement(By.XPath("//div[@class='form-group'][5]/label/span/input")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout")));
          IList<IWebElement>products= driver.FindElements(By.TagName("app-card"));
            foreach (IWebElement product in products)
            {
                //expectedProducts ın içinde yer alan alanlar card da var mı 
                if(expectedProducts.Contains(product.FindElement(By.CssSelector(".card-title a")).Text))
                {
                    //click card
                    product.FindElement(By.CssSelector(".card-footer button")).Click();

                }
               TestContext.Progress.WriteLine(product.FindElement(By.CssSelector(".card-title a")).Text);

            }//sepete eklenen ürünler ile beklenen sonuç eşleşiyomu
            driver.FindElement(By.PartialLinkText("Checkout")).Click();
         IList<IWebElement> chechoutCards=driver.FindElements(By.CssSelector("h4 a"));
            for(int i = 0; i < chechoutCards.Count; i++)
            {
               actualProducts[i]= chechoutCards[i].Text;
            }
            Assert.AreEqual(expectedProducts, actualProducts);
            //chechout butonuyla alakalı işlemler
            driver.FindElement(By.CssSelector(".btn-success")).Click();
            //inputa India seçeneğini seçiyoruz
            driver.FindElement(By.Id("country")).SendKeys("ind");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("India")));
            driver.FindElement(By.LinkText("India")).Click();
            //chechbox ı seçili hale getiriyoruz
            driver.FindElement(By.CssSelector("label[for*='checkbox2']")).Click();
            //purchase butonunu tetikliyoruz
            driver.FindElement(By.CssSelector("[value='Purchase']")).Click();
            //alerte gelen succes ya da error mesajını yakalamam
            String confirText=driver.FindElement(By.CssSelector(".alert-success")).Text;
            StringAssert.Contains("Success", confirText);
        }
    }
}
