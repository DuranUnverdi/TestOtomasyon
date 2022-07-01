using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpSelFramework.pageObjects
{
    public class ProductsPage
    {

        IWebDriver driver;
        By cardTitle = By.CssSelector(".card-title a");
        public ProductsPage(IWebDriver driver)
        {
            this.driver = driver;
            
            PageFactory.InitElements(driver, this);//sendkeys("rahul ")gibi işlemler yapmamızı pagefactory sağlar
        }
        [FindsBy(How = How.TagName, Using = "app-card")]
        private IList<IWebElement> cards;

        public void waitForPageDisplay()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout")));
        }
        public  IList<IWebElement> getCards()
        {
            return cards;
        }
        public By getCardTitle()
        {
            return cardTitle;
        }
    }
}
