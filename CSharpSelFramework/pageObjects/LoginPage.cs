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

        [FindsBy(How = How.XPath, Using = "//div[@class='form-group'][5]/label/span/input")]
        private IWebElement checkbox;

        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement password;

        [FindsBy(How = How.CssSelector, Using = "input[value='Sign In']")]
        private IWebElement signInButton;

        public void validLogin(string user,string pass)
        {
            username.SendKeys(user);
            password.SendKeys(pass);
            checkbox.Click();
            signInButton.Click();
        }
        public IWebElement GetUserName()
        {
            return username;
        }
    }
}
