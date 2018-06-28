using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using TCCApplication.Utilities;

namespace TCCApplication
{
    // Verify that driver is on correct page
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
            Thread.Sleep(2000);
            try
            {
                Assert.AreEqual(MemberPage, _driver.Url);
            }
            catch  (Exception e)
            {
                _results.AddFailure(e);
            }
        }

        /// <summary>
        /// Verify that user login attempt has failed. User should remain on the Main Page.
        /// </summary>
        public void VerifyLoginFailed()
        {
            try
            {
                Assert.AreEqual(MainPage, _driver.Url);
            }
            catch (Exception e)
            {
                _results.AddFailure(e);
            }
        }

        /// <summary>
        /// Verify that the user logout attempt has succeeded. User should be redirected back to Main Page.
        /// </summary>
        public void VerifyLogoutPassed()
        {
            try
            {
                Assert.AreEqual(MainPage, _driver.Url);
            }
            catch (Exception e)
            {
                _results.AddFailure(e);
            }
        }

        /// <summary>
        /// Verify that user logout attempt has failed.
        /// </summary>
        public void VerifyLogoutFailed()
        {
            Console.WriteLine("TODO: Finish me!");
        }

        /// <summary>
        /// Returns 1 if the database table is empty; otherwise returns 0
        /// </summary>
        private int TableIsEmpty()
        {
            DriverUtilities.ElementAccessorType how = DriverUtilities.ElementAccessorType.ClassName;

            int empty = 0;
            string emptyTableSelector = "dataTables_empty";
            string displayText = "No matching records found.";

            //_driverUtils.ExplicitWait(how, emptyTableSelector, 30);
            Thread.Sleep(2000);

            // Returns true if table is empty
            if (_utilsValidation.VerifyDisplayedText(how, emptyTableSelector, displayText))
            {
                empty = 1;
            }

            return empty;
        }

        /// <summary>
        /// Verify that a database table is present on page
        /// </summary>
        public void VerifyTableIsPresent()
        {
            try
            {
                Assert.AreEqual(0, TableIsEmpty());
            }
            catch (Exception e)
            {
                _results.AddFailure(e);
            }
        }

        /// <summary>
        /// Verify that a database table is NOT present on page
        /// </summary>
        public void VerifyTableIsNotPresent()
        {
            try
            {
                Assert.AreEqual(1, TableIsEmpty());
            }
            catch (Exception e)
            {
                _results.AddFailure(e);
            }
        }
    }
}