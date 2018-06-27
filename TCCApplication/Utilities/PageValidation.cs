using System;
using NUnit.Framework;
using OpenQA.Selenium;

namespace TCCApplication
{
    // Verify that driver is on correct page
    public class PageValidation
    {
        private IWebDriver _driver;

        public static string MainPage = "https://tcc.alpha.devca.net/";
        public static string MemberPage = "https://tcc.alpha.devca.net/Member/List";
        public static string JasonTurleyAppProfile = "https://tcc.alpha.devca.net/AppRec/SearchDetail?FirstName=Jason&LastName=&Email=&PostalCode=&CommonAppId=&CEEBCode=&SchoolName=&City=&State=&Type=&RecID=&IsPreviousSeason=false";

        public PageValidation(IWebDriver driver)
        {
            this._driver = driver;
        }

        /// <summary>
        /// Verify that user has successfully logged into TCC. A successful
        /// login will redirect user to the Member Page
        /// </summary>
        public void VerifyLoginPassed()
        {
            Assert.AreEqual(MemberPage, _driver.Url);
        }

        public void VerifyLoginFailed()
        {
            Assert.AreEqual(MainPage, _driver.Url);
        }
    }
}