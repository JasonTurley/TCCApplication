using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace TCCApplication
{
    public class DriverUtilities
    {

        private IWebDriver _driver;

        public enum ElementType
        {
            ID,
            NAME,
            LINKTEXT,
            XPATH
        }

        public DriverUtilities(IWebDriver driver)
        {
            this._driver = driver;
        }

        /// <summary>
        /// Selects HTML element using IWebdriver instance
        /// </summary>
        /// <param name="type"></param>
        /// <param name="elementName"></param>
        public void FindElementBy(ElementType type, string elementName)
        {
            switch (type)
            {
                case ElementType.ID:
                    _driver.FindElement(By.Id(elementName));            
                    break;
                case ElementType.NAME:
                    _driver.FindElement(By.Name(elementName));
                    break;
                case ElementType.LINKTEXT:
                    _driver.FindElement(By.LinkText(elementName));
                    break;
                case ElementType.XPATH:
                    _driver.FindElement(By.XPath(elementName));
                    break;
                default:
                    throw new Exception("Element type not currently supported.");

            }
        }

        public void EnterText(string text)
        {

        }
    }
}
