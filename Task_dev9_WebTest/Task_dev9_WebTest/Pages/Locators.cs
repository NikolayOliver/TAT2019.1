using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace Task_dev9_WebTest.Pages
{
    /// <summary>
    /// class has locators of each page in task
    /// </summary>
    public class Locators
    {
        /// <summary>
        /// locators for each rambler page
        /// </summary>
        public class RamblerLocators
        {
            /// <summary>
            /// locators for login page
            /// </summary>
            public class LoginPage
            {
                public static string LoginField { get; } = "//input[@id=\"login\"][ancestor::div[@class=\"rui-FormGroup-inner\"]]";
                public static string Frame { get; } = "//iframe";
                public static string PassField { get; } = "//input[@name=\"password\"]";
                public static string ButtonEntrance { get; } = "//span[@class=\"rui-Button-content\"]";
            }
           
        }
        // korolevnikola297345@rambler.ru
        // 123456789Qwer
    }
}
