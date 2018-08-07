///<summary>
/// PageValidation.cs - Verify that after an action, the correct screen is loaded.
/// </summary>
using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using TCCApplication.Utilities;

namespace TCCApplication
{
    public class PageValidation
    {
        private IWebDriver _driver;
        private Result _results = new Result();

        private DriverUtilities _driverUtils;
        private DriverUtilitiesValidation _utilsValidation;

        public static string MainPage = "https://tcc.alpha.devca.net/";
        public static string MemberPage = "https://tcc.alpha.devca.net/Member/List";

        public PageValidation(IWebDriver driver)
        {
            this._driver = driver;
            this._driverUtils = new DriverUtilities(_driver);
            this._utilsValidation = new DriverUtilitiesValidation(_driver);
        }

        /// <summary>
        /// Verify that user login attempt has succeeded. User should be redirected to Member Page.
        /// </summary>
        public void VerifyLoginPassed()
        {
            _utilsValidation.ImplicitWait(5);
            string actualText = _utilsValidation.GetText(DriverUtilities.ElementAccessorType.XPath, "//*[@id='wid-memberList']/header/h2");
            VerifyTextIsDisplayed("Member List", actualText);
            _results.IncrementAmountPassed();
        }

        /// <summary>
        /// Verify that user is on the login screen
        /// </summary>
        public void VerifyAtLoginScreen()
        {
            Assert.AreEqual("https://tcc.alpha.devca.net/", _driver.Url);
            _results.IncrementAmountPassed();
        }

        /// <summary>
        /// Verify that user logout attempt has failed.
        /// </summary>
        public void VerifyLogoutFailed()
        {
            Console.WriteLine("TODO");
        }

        /// <summary>
        /// Verify that actualText is present on the page
        /// </summary>
        /// <param name="actualText"></param>
        /// <param name="expectedText"></param>
        public void VerifyTextIsDisplayed(string expectedText, string actualText)
        {
            Assert.AreEqual(expectedText, actualText);
        }

        /// <summary>
        /// Verify that actualText is NOT present on the page
        /// </summary>
        /// <param name="expected"></param>
        /// <param name="actual"></param>
        public void VerifyTextIsNotDisplayed(string expected, string actual)
        {
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        /// Verify that message "No matching records found." is displayed
        /// </summary>
        public void VerifyNoResultsFound()
        {
            string actualText = _utilsValidation.GetText(DriverUtilities.ElementAccessorType.ClassName, "dataTables_empty");
            VerifyTextIsDisplayed("No matching records found.", actualText);
        }

        /// <summary>
        /// Verify that a results table is loaded and the message "No matching records found."
        /// is not displayed
        /// </summary>
        public void VerifyResultsAreFound()
        {
             string actualText = _utilsValidation.GetText(DriverUtilities.ElementAccessorType.ClassName, "dataTables_empty");
            VerifyTextIsNotDisplayed("No matching records found.", actualText);
        }
    }
}