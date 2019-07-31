using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;


namespace Task_dev9_WebTest.Pages
{
    /// <summary>
    /// login to rambler account
    /// </summary>
    public class LoginPageRambler
    {
        IWebDriver Driver { get; }
        IWebElement LoginField { get; set; }
        IWebElement PassField { get; set; }
        IWebElement ButtonEnrance { get; set; }
        WebDriverWait Wait { get; set; }

        string xpathLoginField = Locators.RamblerLocators.LoginPage.LoginField;
        string xpathFrame = Locators.RamblerLocators.LoginPage.Frame;
        string xpathPassField = Locators.RamblerLocators.LoginPage.PassField;
        string xpathButtonentrance = Locators.RamblerLocators.LoginPage.ButtonEntrance;
        string login = "korolevnikola297345@rambler.ru";
        string pass = "123456789Qwer";

        public LoginPageRambler(IWebDriver driver, string login, string pass)
        {
            Driver = driver;
            Driver.Navigate().GoToUrl("https://mail.rambler.ru/");
            Wait = new WebDriverWait(Driver, TimeSpan.FromMinutes(1));
            Initiallize();
            this.login = login;
            this.pass = pass;
        }
      
        /// <summary>
        /// initillize web element with which will need to work
        /// </summary>
        void Initiallize()
        {
            Wait.Until(t => Driver.FindElements(By.XPath(xpathFrame)).Any());
            Driver.SwitchTo().Frame(Driver.FindElement(By.XPath(xpathFrame)));
            Wait.Until(t => Driver.FindElements(By.XPath(xpathLoginField)).Any());
            LoginField = Driver.FindElement(By.XPath(xpathLoginField));
            Wait.Until(t => Driver.FindElements(By.XPath(xpathPassField)).Any());
            PassField = Driver.FindElement(By.XPath(xpathPassField));
            Wait.Until(t => Driver.FindElements(By.XPath(xpathButtonentrance)).Any());
            ButtonEnrance = Driver.FindElement(By.XPath(xpathButtonentrance));
        }

        /// <summary>
        /// input login and pass and go to main page of rambler
        /// </summary>
        public RamblerPage GoToLoginPage()
        {
            LoginField.SendKeys(login);
            PassField.SendKeys(pass);
            ButtonEnrance.Click();
            return new RamblerPage();
        }
    }
}
