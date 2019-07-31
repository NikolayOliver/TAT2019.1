using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support;
using OpenQA.Selenium;
using NUnit.Framework;
using Task_dev9_WebTest.Pages;

namespace Task_dev9_WebTest
{
    [TestFixture]
    public class Tests
    {
        LoginPageRambler homePageMail;
        IWebDriver driver;
        string xpathWrongInput = "//div[text()=\"неправильная почта или пороль\"]";

        [SetUp]
        public void startBrowser()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
        }

        [Test]
        [TestCase("korolevnikola297345@rambler.ru", "123456789Qwer")]
        [TestCase("korolevnikola297345", "123456789Qwer")]
        public void LoginPageTest(string login, string pass)
        {
            LoginPageRambler loginPageRambler = new LoginPageRambler(driver, login, pass);
            loginPageRambler.GoToLoginPage();
            Assert.IsTrue(driver.FindElements(By.XPath(xpathWrongInput)).Count == 0);
        }

        [Test]
        [TestCase("korolevsdfdf","1234567890Qwer")]
        [TestCase("","1234567890Qwer")]
        [TestCase("korolevnikola297345@rambler.ru","")]
        public void WrongLoginPageTest(string login, string pass)
        {
            var loginPageRambler = new LoginPageRambler(driver, login, pass);
            loginPageRambler.GoToLoginPage();
            Assert.IsTrue(driver.FindElements(By.XPath(xpathWrongInput)).Count == 1);
        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
        
    }
}
