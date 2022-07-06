using CSharpSelFramework.pageObjects;
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
        [TestCase("rahulshettyacademy", "learning")]//doğru değerler 
        [TestCase("rahulshetty", "learning")]//yanlış derğerler
        //testcaseden gelen parametre değerleri username ve passwordun içini dolduruyo
        public void EndToEndFlow(String username,String password)
        {
            String[] expectedProducts = { "iphone X", "Blackberry"};
            String[] actualProducts = new String[2];

            //LoginPage base repository gibi düşünebiliriz 
            LoginPage loginPage = new LoginPage(getDriver());
            ProductsPage productPage=loginPage.validLogin(username,password);
            productPage.waitForPageDisplay();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            IList<IWebElement> products = productPage.getCards();
            foreach (IWebElement product in products)
            {
                //expectedProducts ın içinde yer alan alanlar card da var mı 
                if (expectedProducts.Contains(product.FindElement(productPage.getCardTitle()).Text)) 
                {
                    //click card
                    product.FindElement(productPage.addToChartButton()).Click();

                }
               TestContext.Progress.WriteLine(product.FindElement(By.CssSelector(".card-title a")).Text);

            }//sepete eklenen ürünler ile beklenen sonuç eşleşiyomu
           CheckoutPage checkOutPage= productPage.checkOut();
            IList<IWebElement> chechoutCards = checkOutPage.getCards();
            for (int i = 0; i < chechoutCards.Count; i++)
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
