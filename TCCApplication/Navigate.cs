using System;
using OpenQA.Selenium;

namespace TCCApplication
{
    public class Navigate
    {
        private IWebDriver _driver;
        private DriverUtilities _utils;

        public Navigate(IWebDriver driver)
        {
            this._driver = driver;
            this._utils = new DriverUtilities(_driver);
        }

        /// <summary>
        /// Navigate to TCC Login Page
        /// </summary>
        public void NavigateToLoginPage(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(Pages.MainPage);
            driver.Manage().Window.Maximize();
        }

        /// <summary>
        /// Navigate App Search Rec page. Assumes the user is already logged in
        /// </summary>
        public void NavigateToSearchPage(IWebDriver driver)
        {
            // Creating a new instance keeps LogInUser() argument free;
            // otherwise, we'd need to call it like so: LogInUser(driver) to get the correct IWebDriver instance
            AppLoginLogout app = new AppLoginLogout(driver);
            app.LogInUser();
            _utils.Wait(driver, 10);
            _utils.Click(DriverUtilities.ElementAccessorType.ID, "loadingContainer");
            _utils.Wait(driver, 10);
            _utils.Click(DriverUtilities.ElementAccessorType.XPath, "//*[@data-bind='click:MenuBar.redirectToAppRecSearch']");
        }

        /// <summary>
        /// Selects `name` from App Rec School Search dropdown box
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="name"></param>
        public void SelectSearch(IWebDriver driver, string name)
        {
            string searchFor = name.ToLower();
            string value;

            if (searchFor == "app" || searchFor == "applicants")
                value = "App";
            else if (searchFor == "rec" || searchFor == "recommenders")
                value = "Rec";
            else if (searchFor == "college")
                value = "College";
            else
                value = "HighSchool";

            _utils.Wait(driver, 5);
            _utils.Click(DriverUtilities.ElementAccessorType.ID, "selectSearchObject");
            _utils.Click(DriverUtilities.ElementAccessorType.XPath, "//option[@value='" + value + "']");
        }
    }
}
