using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace TCCApplication
{
    public static class DriverUtilities
    {

        //private IWebDriver _driver;

        public static void Wait(IWebDriver driver, double value)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(value);
        }
        
    }
}
