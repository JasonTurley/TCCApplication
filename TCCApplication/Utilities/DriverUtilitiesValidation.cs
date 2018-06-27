using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TCCApplication.Utilities
{
    class DriverUtilitiesValidation
    {
        private StringBuilder _resultString = new StringBuilder();

        private IWebDriver _driver;
        private DriverUtilities _utils;

        public DriverUtilitiesValidation(IWebDriver driver)
        {
            this._driver = driver;
            this._utils = new DriverUtilities(_driver);
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
                _utils.EnterText(how, elementName, text);
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
                _utils.Click(how, elementName);
            }
            catch (Exception e)
            {
                _resultString.Append(e.Message);
            }

            return _resultString.ToString();
        }


        public string SelectDropdownItem(string itemToFind)
        {
            _resultString.Clear();

            try
            {
                _utils.SelectDropdownItem(itemToFind);
            }
            catch (Exception e)
            {
                _resultString.Append(e.Message);
            }

            return _resultString.ToString();
        }
    }
}
