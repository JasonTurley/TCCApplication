///<summary>
/// Wrapper functions for commonly used Selenium WebDriver functions.
/// Citation: https://github.com/CommonApp/QA/blob/master/CAOCloudRegressionTest/CommonUtilities/Validation/CommonUtil.cs
/// </summary>
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace TCCApplication.Utilities
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
        /// Get Web Element based on Selenium accessor type.
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
        /// Enters `text` into a text box.
        /// </summary>
        /// <param name="how"></param>
        /// <param name="elementName"></param>
        /// <param name="text"></param>
        public void EnterText(ElementAccessorType how, string elementName, string text)
        {
            By findBy = FindElementBy(how, elementName);
            this._driver.FindElement(findBy).Clear();
            this._driver.FindElement(findBy).SendKeys(text);
        }

        /// <summary>
        /// Click on an element.
        /// </summary>
        /// <param name="how"></param>
        /// <param name="elementName"></param>
        public void Click(ElementAccessorType how, string elementName)
        {
            By findBy = FindElementBy(how, elementName);
            this._driver.FindElement(findBy).Click();
        }

        /// <summary>
        /// Clicks accordian folder.
        /// </summary>
        /// <param name="how"></param>
        /// <param name="elementName"></param>
        public void ClickAccordion(ElementAccessorType how, string elementName)
        {
            Click(how, elementName);
        }

        /// <summary>
        /// Sets an implicit wait time in seconds.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="seconds">Amount of seconds to wait</param>
        public void ImplicitWait(double seconds)
        {
            this._driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
        }

        /// <summary>
        /// Sets an explicit wait time in seconds.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="seconds"></param>
        /// <param name="elementName"></param>
        public void ExplicitWait(ElementAccessorType how, string elementName, double seconds)
        {
            WebDriverWait wait = new WebDriverWait(this._driver, TimeSpan.FromSeconds(seconds));
            By findBy = FindElementBy(how, elementName);
            wait.Until(drv => drv.FindElement(findBy));    
        }

        /// <summary>
        /// Check if element is present on page or not
        /// </summary>
        /// <param name="how"></param>
        /// <param name="elementName"></param>
        /// <returns></returns>
        public bool IsElementPresent(ElementAccessorType how, string elementName)
        {
            By findBy = FindElementBy(how, elementName);

            // Note: FindElement throws an exception if it cannot find element. This is handled in DriverUtilitiesValidation
            return _driver.FindElement(findBy).Displayed;   
        }

        /// <summary>
        /// Get the displayed text 
        /// </summary>
        /// <param name="how"></param>
        /// <param name="element"></param>
        /// <returns>String</returns>
        public string GetText(ElementAccessorType how, string element)
        {
            string actualValue = null;
            By findBy = FindElementBy(how, element);
            actualValue = this._driver.FindElement(findBy).Text;
            return actualValue;
        }

        /// <summary>
        /// Clicks on the first result link, if available. Otherwise, outputs error message
        /// </summary>
        /// <param name="driver"></param>
        public static void ClickFirstResult(IWebDriver driver)
        {
            string firstResultXPath = "//td[@data-bind='text:Email']";

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

        /// <summary>
        /// Selects `itemToFind` from App Rec School Search dropdown menu
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="name"></param>
        public void SelectDropdownItem(string itemToFind)
        {
            string value;

            // Find item to select from the dropdown menu
            switch (itemToFind.ToLower())
            {
                case "applicant":
                case "applicants":
                case "app":
                    value = "App";
                    break;

                case "recommender":
                case "recommenders":
                case "rec":
                    value = "Rec";
                    break;

                case "college":
                case "colleges":
                    value = "College";
                    break;

                case "high school":
                case "high schools":
                    value = "HighSchool";
                    break;

                default:
                    throw new Exception("No `itemToFind` specified.");
            }

            Click(DriverUtilities.ElementAccessorType.ID, "selectSearchObject");
            Click(DriverUtilities.ElementAccessorType.XPath, "//option[@value='" + value + "']");
        }
    }
}
