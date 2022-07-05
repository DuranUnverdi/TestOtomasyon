using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpSelFramework.pageObjects
{
    public class CheckoutPage
    {
        IWebDriver driver;
        public CheckoutPage(IWebDriver driver)
        {
            this.driver = driver;

            PageFactory.InitElements(driver, this);//sendkeys("rahul ")gibi işlemler yapmamızı pagefactory sağlar
        }
        [FindsBy(How = How.CssSelector, Using = "h4 a")]
        private IList<IWebElement> checkoutCards;

        [FindsBy(How = How.CssSelector, Using = ".btn-success")]
        private IWebElement checkoutButtons;

        public IList<IWebElement> getCards()
        {
            return checkoutCards;
        }
        public void checkOut()
        {
            checkoutButtons.Click();
        }
    }
}
