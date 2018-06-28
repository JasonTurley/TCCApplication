using System;
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

        public static string MainPage = "https://tcc.alpha.devca.net/";
        public static string MemberPage = "https://tcc.alpha.devca.net/Member/List";
        public static string JasonTurleyAppProfile = "https://tcc.alpha.devca.net/AppRec/SearchDetail?FirstName=Jason&LastName=&Email=&PostalCode=&CommonAppId=&CEEBCode=&SchoolName=&City=&State=&Type=&RecID=&IsPreviousSeason=false";

        public PageValidation(IWebDriver driver)
        {
            this._driver = driver;
            this._driverUtils = new DriverUtilities(_driver);
        }

        /// <summary>
        /// Verify that user login attempt has succeeded. User should be redirected to Member Page.
        /// </summary>
        public void VerifyLoginPassed()
        {
            _driverUtils.ImplicitWait(30);
            Assert.AreEqual(MemberPage, _driver.Url);
        }

        /// <summary>
        /// Verify that user login attempt has failed. User should remain on the Main Page.
        /// </summary>
        public void VerifyLoginFailed()
        {
            _driverUtils.ImplicitWait(30);
            Assert.AreEqual(MainPage, _driver.Url);
        }

        /// <summary>
        /// Verify that the user logout attempt has succeeded. User should be redirected back to Main Page.
        /// </summary>
        public void VerifyLogoutPassed()
        {
            _driverUtils.ImplicitWait(30);
            Assert.AreEqual(MainPage, _driver.Url);
        }


        /// <summary>
        /// Verify that user logout attempt has failed.
        /// </summary>
        public void VerifyLogoutFailed()
        {
            _driverUtils.ImplicitWait(30);
            Console.WriteLine("TODO: Finish me!");
        }
    }
}