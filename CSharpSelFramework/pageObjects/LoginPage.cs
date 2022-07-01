using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpSelFramework.pageObjects
{
    public class LoginPage
    {
        private IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        //PageObject factory --pageobject library yi nuget dan ekliyoruz

        [FindsBy(How=How.Id, Using = "username")]
        private IWebElement username;
        public IWebElement GetUserName()
        {
            return username;
        }
    }
}
