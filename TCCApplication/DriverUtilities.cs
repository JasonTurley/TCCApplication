// Citiations:
//  - QA Project Code Review https://cawiki.atlassian.net/wiki/spaces/CA2/pages/983252/QA+project+Code+Review
//  - https://github.com/CommonApp/QA/blob/master/CAOCloudRegressionTest/CommonUtilities/Validation/CommonUtil.cs         
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace TCCApplication
{
    public class DriverUtilities
    {
        private IWebDriver _driver;

        public enum ElementAccessorType
        {
            ID,
            ClassName,
            XPath
        }

        public DriverUtilities(IWebDriver driver)
        {
            this._driver = driver;
        }

        /// <summary>
        /// Get Web Element based on Selenoium accessor type
        /// </summary>
        /// <param name="how"></param>
        /// <param name="elementName"></param>
        /// <returns>By</returns>
        public By FindElementBy(ElementAccessorType how, string elementName)
        {
            By findBy = null;
            switch (how)
            {
                case ElementAccessorType.ID:
                    findBy = By.Id(elementName);
                    break;
                case ElementAccessorType.ClassName:
                    findBy = By.ClassName(elementName);
                    break;
                case ElementAccessorType.XPath:
                    findBy = By.XPath(elementName);
                    break;
                default:
                    findBy = By.Id(elementName);
                    break;
            }

            return findBy;
        }

        /// <summary>
        /// Enter text into text box.
        /// </summary>
        /// <param name="how"></param>
        /// <param name="elementName"></param>
        /// <param name="text"></param>
        public void EnterText(ElementAccessorType how, string elementName, string text)
        {
            By findBy = FindElementBy(how, elementName);
            ImplicitWait(_driver, 10);
            this._driver.FindElement(findBy).Clear();
            this._driver.FindElement(findBy).SendKeys(text);
        }

        /// <summary>
        /// Clicks on an element.
        /// </summary>
        /// <param name="how"></param>
        /// <param name="elementName"></param>
        public void Click(ElementAccessorType how, string elementName)
        {
            By findBy = FindElementBy(how, elementName);
           // ExplicitWait(_driver, elementName);
            this._driver.FindElement(findBy).Click();
        }

        /// <summary>
        /// Sets an implicit wait time in seconds.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="seconds">Amount of seconds to wait</param>
        public void ImplicitWait(IWebDriver driver, double seconds)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
        }
        
        public void ExplicitWait(IWebDriver driver, string idToFind)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(drv => drv.FindElement(By.Id(idToFind)));
        }

        /// <summary>
        /// Clicks on the first result link, if available. Otherwise, outputs error message
        /// </summary>
        /// <param name="driver"></param>
        public void ClickFirstResult(IWebDriver driver)
        {
            string firstResultXPath = "//td[@data-bind='text:FirstName']";

            try
            {
                driver.FindElement(By.XPath(firstResultXPath)).Click();
            }
            catch (OpenQA.Selenium.NoSuchElementException e)
            {
                if (e.Message != null)
                    Console.WriteLine("NoSuchElementException: {0}", e.Message);
            }
        }
    }
}
