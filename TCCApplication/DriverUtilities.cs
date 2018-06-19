using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace TCCApplication
{
    public static class DriverUtilities
    {

        //private IWebDriver _driver;
        public static void Wait(IWebDriver driver, double seconds)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
        }
        
        public static void ClickFirstLink(IWebDriver driver)
        {
            // Click on the first link that appears
            string xPath = "//td[@data-bind='text:Email']";

            try
            {
                driver.FindElement(By.XPath(xPath)).Click();
            }
            catch (OpenQA.Selenium.NoSuchElementException e)
            {
                if (e.Message != null)
                    Console.WriteLine("NoSuchElementException: {0}", e.Message);
            }
        }
    }
}
