using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearning
{
    public class AlertAction
    {
        IWebDriver driver;
        [SetUp]
        public void StartBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/AutomationPractice/";
        }
        [Test]
        public void test_Alert()
        {
            String name = "Duran";
            driver.FindElement(By.CssSelector("#name")).SendKeys(name);//inputa duran yazdırdık
            driver.FindElement(By.CssSelector("input[onclick*='displayConfirm']")).Click();//Confirm butonu tetiklendi
            String alertText = driver.SwitchTo().Alert().Text;//Alertte gelen mesajı değişkene atıyoruz
            driver.SwitchTo().Alert().Accept();//alertte açılan cancel ya da ok butonunu seçmek için burada ok butonunu tetikliyoruz
            //driver.SwitchTo().Alert().Dismiss();//Burada ise cancel ı seçiyoruz
            StringAssert.Contains(name, alertText);
        }
        [Test]
        public void testAutoSuggestiveDropDowns()
        {
            driver.FindElement(By.Id("autocomplete")).SendKeys("ind");//inputa ind yazıyoruz
            Thread.Sleep(3000);
            IList<IWebElement> options= driver.FindElements(By.CssSelector(".ui-menu-item div"));
            foreach(IWebElement option in options)
            {
                if (option.Text.Equals("India"))
                {
                    option.Click(); 
                }
            }
            //burada autocomplete kısmının value değerini ekrana basıyoruz
            TestContext.Progress.WriteLine(driver.FindElement(By.Id("autocomplete")).GetAttribute("value"));

        }
        [Test]
        public void test_Actions()
        {
            //Anasayfadaki more kısmının popup ını açıyoruz
            driver.Url = "https://rahulshettyacademy.com";
            Actions act = new Actions(driver);
            act.MoveToElement(driver.FindElement(By.CssSelector("a.dropdown-toggle"))).Perform();
            //açılan menüde tıklama işlemi
            //driver.FindElement(By.XPath("//ul[@class='dropdown-menu']/li[1]/a")).Click();
            act.MoveToElement(driver.FindElement(By.XPath("//ul[@class='dropdown-menu']/li[1]/a"))).Click().Perform();

        }
        [Test]
        public void frames()
        {
            //sayfada aşşağı gidip All Access Planı tetiklemek
            //scroll kaydırma
          IWebElement frameScroll= driver.FindElement(By.Id("courses-iframe"));
           IJavaScriptExecutor js= (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);",frameScroll);
            //id,name,index
            driver.SwitchTo().Frame("courses-iframe");
            driver.FindElement(By.LinkText("All Access Plan")).Click();
        }
    }
}
