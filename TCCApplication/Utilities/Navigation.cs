/// <summary>
/// Navigation.cs - Helper funtions to naviagte the TCC site.
/// </summary>

using System;
using OpenQA.Selenium;
using TCCApplication.Utilities;

namespace TCCApplication
{
    public class Navigation
    {
        private IWebDriver _driver;
        private DriverUtilities _utils;
        private DriverUtilitiesValidation _utilsValidation;

        public Navigation(IWebDriver driver)
        {
            this._driver = driver;
            this._utils = new DriverUtilities(_driver);
            this._utilsValidation = new DriverUtilitiesValidation(_driver);
        }

        /// <summary>
        /// Navigate to TCC Login Page
        /// </summary>
        public void NavigateToLoginPage(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(PageValidation.MainPage);
            driver.Manage().Window.Maximize();
        }

        /// <summary>
        /// Navigate to TCC Member Page
        /// </summary>
        /// <param name="driver"></param>
        public void NavigateToMemberPage(IWebDriver driver, UserLoginLogout userLog)
        {
            if (!userLog.IsSignedIn())
            {
                userLog.LoginUser();
            }
            driver.Navigate().GoToUrl(PageValidation.MemberPage);
        }

        /// <summary>
        /// Navigate App Search Rec page. Assumes the user is already logged in
        /// </summary>
        /// <param name="driver"></param>
        public void NavigateToSearchPage(IWebDriver driver)
        {
            UserLoginLogout temp = new UserLoginLogout(driver);
            temp.LoginUser();

            _utils.ExplicitWait(DriverUtilities.ElementAccessorType.ID, "loadingContainer", 30);
            _utilsValidation.Click(DriverUtilities.ElementAccessorType.ID, "loadingContainer");
            _utilsValidation.Click(DriverUtilities.ElementAccessorType.XPath, "//*[@data-bind='click:MenuBar.redirectToAppRecSearch']");
        }
    }
}
