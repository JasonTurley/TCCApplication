using System;
using OpenQA.Selenium;

namespace TCCApplication
{
    public class Navigation
    {
        private IWebDriver _driver;
        private DriverUtilities _utils;

        public Navigation(IWebDriver driver)
        {
            this._driver = driver;
            this._utils = new DriverUtilities(_driver);
        }

        /// <summary>
        /// Navigate to TCC Login Page
        /// </summary>
        public void NavigateToLoginPage(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(PageLinks.MainPage);
            driver.Manage().Window.Maximize();
        }

        /// <summary>
        /// Navigate to TCC Member Page
        /// </summary>
        /// <param name="driver"></param>
        public void NavigateToMemberPage(IWebDriver driver, UserLoginLogout userLog)
        {
            if (!userLog.IsLoggedIn)
            {
                userLog.LogInUser();
            }
            driver.Navigate().GoToUrl(PageLinks.MemberPage);
        }

        /// <summary>
        /// Navigate App Search Rec page. Assumes the user is already logged in
        /// </summary>
        /// <param name="driver"></param>
        public void NavigateToSearchPage(IWebDriver driver)
        {
            UserLoginLogout temp = new UserLoginLogout(driver);
            temp.LogInUser();

            _utils.ExplicitWait(driver, 10, DriverUtilities.ElementAccessorType.ID, "loadingContainer");
            _utils.Click(DriverUtilities.ElementAccessorType.ID, "loadingContainer");
            _utils.ImplicitWait(driver, 10);
            _utils.Click(DriverUtilities.ElementAccessorType.XPath, "//*[@data-bind='click:MenuBar.redirectToAppRecSearch']");
        }
    }
}
