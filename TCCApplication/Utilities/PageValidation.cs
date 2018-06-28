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
        private DriverUtilities _driverUtils;
        private DriverUtilitiesValidation _utilsValidation;

        public static string MainPage = "https://tcc.alpha.devca.net/";
        public static string MemberPage = "https://tcc.alpha.devca.net/Member/List";
        public static string JasonTurleyAppProfile = "https://tcc.alpha.devca.net/AppRec/SearchDetail?FirstName=Jason&LastName=&Email=&PostalCode=&CommonAppId=&CEEBCode=&SchoolName=&City=&State=&Type=&RecID=&IsPreviousSeason=false";

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
        }

        /// <summary>
        /// Verify that user login attempt has failed. User should remain on the Main Page.
        /// </summary>
        public void VerifyLoginFailed()
        {
            Assert.AreEqual(MainPage, _driver.Url);
        }

        /// <summary>
        /// Verify that the user logout attempt has succeeded. User should be redirected back to Main Page.
        /// </summary>
        public void VerifyLogoutPassed()
        {
            Assert.AreEqual(MainPage, _driver.Url);
        }

        /// <summary>
        /// Verify that user logout attempt has failed.
        /// </summary>
        public void VerifyLogoutFailed()
        {
            Console.WriteLine("TODO: Finish me!");
        }

        /// <summary>
        /// Verify that searched for member is present on page
        /// </summary>
        /// <param name="how"></param>
        /// <param name="elementName"></param>
        public void VerifyMemberSearchPassed(DriverUtilities.ElementAccessorType how, string elementName)
        {
            // FIXME: works, but not practical
            int pass = 0;

            if (_utilsValidation.IsElementPresent(how, elementName))
            {
                pass = 1;
            } 

            Assert.AreEqual(1, pass);
        }

        /// <summary>
        /// Check if a table is present
        /// </summary>
        /// <returns></returns>
        public int TableIsPresent()
        {
            DriverUtilities.ElementAccessorType how = DriverUtilities.ElementAccessorType.ClassName;

            int present = 0;
            string emptyTableSelector = "dataTables_empty";
            string displayText = "No matching records found.";

            //_driverUtils.ExplicitWait(how, emptyTableSelector, 30);
            Thread.Sleep(2000);

            // Returns true if table is empty
            if (_utilsValidation.VerifyDisplayedText(how, emptyTableSelector, displayText) == false)
            {
                present = 1;
            }

            return present;
        }

        public void VerifyTableIsPresent()
        {
            Assert.AreEqual(1, TableIsPresent());
        }

        public void VerifyTableIsNotPresent()
        {
            Assert.AreEqual(0, TableIsPresent());
        }
    }
}