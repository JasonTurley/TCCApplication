using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using TCCApplication.Utilities;

namespace TCCApplication
{
    // Verify that tests direct user to the correct page.
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
            Assert.AreEqual(MemberPage, _driver.Url);
            _results.IncrementPassCount();
        }

        /// <summary>
        /// Verify that user login attempt has failed. User should remain on the Main Page.
        /// </summary>
        public void VerifyLoginFailed()
        {
            Assert.AreEqual(MainPage, _driver.Url);
            _results.IncrementPassCount();
        }

        /// <summary>
        /// Verify that the user logout attempt has succeeded. User should be redirected back to Main Page.
        /// </summary>
        public void VerifyLogoutPassed()
        {
            Assert.AreEqual(MainPage, _driver.Url);
            _results.IncrementPassCount();
        }

        /// <summary>
        /// Verify that user logout attempt has failed.
        /// </summary>
        public void VerifyLogoutFailed()
        {
            Console.WriteLine("TODO: Finish me!");
        }

        /// <summary>
        /// Returns 1 if search target is present on page
        /// </summary>
        private int TargetIsPresent()
        {
            int isPresent = 1;
            string emptyTableSelector = "dataTables_empty";
            string displayedText = "No matching records found.";
            //Thread.Sleep(2000);

            // Returns true if target is not found
            if (_utilsValidation.VerifyDisplayedText(DriverUtilities.ElementAccessorType.ClassName, emptyTableSelector, displayedText))
            {
                isPresent = 0;
            }

            return isPresent;
        }

        /// <summary>
        /// Verify that the searched for target is present on page. 
        /// </summary>
        public void VerifyTargetIsPresent()
        {
            Assert.NotZero(TargetIsPresent());
            _results.IncrementPassCount();
        }

        /// <summary>
        /// Verify that a database table is NOT present on page
        /// </summary>
        public void VerifyTargetIsNotPresent()
        {
            Assert.Zero(TargetIsPresent());
            _results.IncrementPassCount();            
        }
    }
}