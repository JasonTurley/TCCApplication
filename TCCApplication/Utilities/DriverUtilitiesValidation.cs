/// <summary>
/// DriverUtilitiesValidation.cs - Handles any exceptions thrown by the DriverUtilites class. 
/// 
/// For this reason, it is highly recommended to use this class instead of DriverUtilities.
/// </summary>

using System;
using System.Text;
using OpenQA.Selenium;

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
        /// Sets an implicit wait time in seconds.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="seconds">Amount of seconds to wait</param>
        public string ImplicitWait(double seconds)
        {
            _resultString.Clear();

            try
            {
                _driverUtils.ImplicitWait(seconds);
            }
            catch (Exception e)
            {
                _resultString.Append(e.Message);
            }

            return _resultString.ToString();
        }

        /// <summary>
        /// Sets an explicit wait time in seconds.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="seconds"></param>
        /// <param name="elementName"></param>
        public string ExplicitWait(DriverUtilities.ElementAccessorType how, string elementName, double seconds)
        {
            _resultString.Clear();

            try
            {
                _driverUtils.ExplicitWait(how, elementName, seconds);
            }
            catch (Exception e)
            {
                _resultString.Append(e.Message);    
            }

            return _resultString.ToString();
        }

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
        public bool VerifyDisplayedText(DriverUtilities.ElementAccessorType how, string elementName, string expectedText)
        {
            string actualText = null;

            try
            {
                if (elementName != string.Empty)
                {
                    actualText = _driverUtils.GetText(how, elementName);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed with message: {0}", e.Message);
            }

            return actualText != null;
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
