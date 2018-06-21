using System;
using OpenQA.Selenium;

namespace TCCApplication
{
    public class Navigate
    {
        private IWebDriver _driver;
        private DriverUtilities _utilities;

        public Navigate(IWebDriver driver)
        {
            this._driver = driver;
            this._utilities = new DriverUtilities(_driver);
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
            // Log in the user if they are not already
            AppLoginLogout app = new AppLoginLogout(_driver);
            app.LogInUser();
            _utilities.Wait(_driver, 10);
            driver.FindElement(By.Id("loadingContainer")).Click();
            driver.FindElement(By.XPath("//*[@title='App Rec School Search']")).Click();
            driver.FindElement(By.XPath("//*[@id='left-panel']/nav/ul/li[3]/a")).Click();
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

            _utilities.Wait(_driver, 10);
            driver.FindElement(By.Id("selectSearchObject")).Click();
            driver.FindElement(By.XPath("//option[@value='" + value + "']")).Click();
        }
    }
}
