using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;

namespace TCCApplication.Utilities
{
    public class DriverUtilitiesValidation
    {
        private StringBuilder _resultString = new StringBuilder();

        private IWebDriver _driver;
        private DriverUtilities _driverUtils;

        public DriverUtilitiesValidation(IWebDriver driver)
        {
            this._driver = driver;
            this._driverUtils = new DriverUtilities(_driver);
        }

        //===============================================================================================================================
        // Validate Selenium API Commands
        //===============================================================================================================================


        /// <summary>
        /// Enters `text` into a text box.
        /// </summary>
        /// <param name="how"></param>
        /// <param name="elementName"></param>
        /// <param name="text"></param>
        public string EnterText(DriverUtilities.ElementAccessorType how, string elementName, string text)
        {
            _resultString.Clear();

            try
            {
                _driverUtils.EnterText(how, elementName, text);
            }
            catch (Exception e)
            {
                _resultString.Append(e.Message);
            }

            return _resultString.ToString();
        }

        /// <summary>
        /// Click on an element.
        /// </summary>
        /// <param name="how"></param>
        /// <param name="elementName"></param>
        public string Click(DriverUtilities.ElementAccessorType how, string elementName)
        {
            _resultString.Clear();

            try
            {
                _driverUtils.Click(how, elementName);
            }
            catch (Exception e)
            {
                _resultString.Append(e.Message);
            }

            return _resultString.ToString();
        }

        /// <summary>
        /// Check if element is present on page or not
        /// </summary>
        /// <param name="how"></param>
        /// <param name="elementName"></param>
        /// <returns></returns>
        public bool IsElementPresent(DriverUtilities.ElementAccessorType how, string elementName)
        {
            try
            {
                _driverUtils.IsElementPresent(how, elementName);
                return true;
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element: {0} does not exist.", elementName);
                return false;
            }
        }

        /// <summary>
        /// Verify displayed Text is as expected
        /// </summary>
        /// <param name="how"></param>
        /// <param name="msg"></param>
        /// <param name="elementID"></param>
        /// <param name="expectedText"></param>
        /// <param name="print"></param>
        /// <returns>String</returns>
        public string VerifyDisplayedText(DriverUtilities.ElementAccessorType how, string elementName, string expectedText)
        {
            _resultString.Clear();
            string actualText = null;

            try
            {
                if (elementName != string.Empty)
                {
                    actualText = _driverUtils.GetText(how, elementName);
                }
                Assert.AreEqual(expectedText, actualText);
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed with message: {0}", e.Message);
            }

            return _resultString.ToString();
        }
        /// <summary>
        /// Selects `itemToFind` from App Rec School Search dropdown menu
        /// </summary>
        /// <param name="itemToFind"></param>
        /// <returns></returns>
        public string SelectDropdownItem(string itemToFind)
        {
            _resultString.Clear();

            try
            {
                _driverUtils.SelectDropdownItem(itemToFind);
            }
            catch (Exception e)
            {
                _resultString.Append(e.Message);
            }

            return _resultString.ToString();
        }
    }
}
