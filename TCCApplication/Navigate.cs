using System;
using OpenQA.Selenium;

namespace TCCApplication
{
    public static class Navigate
    {

        /// <summary>
        /// Navigate to TCC Login Page
        /// </summary>
        public static void NavigateToLoginPage(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(Pages.MainPage);
            driver.Manage().Window.Maximize();
        }

        /// <summary>
        /// Goto App Search Rec page. Assumes the user is already logged in
        /// </summary>
        public static void NavigateToSearchPage(IWebDriver driver)
        {
            // Log in the user if they are not already
            AppLoginLogout app = new AppLoginLogout(driver);
            if (app.IsLoggedIn() == false)
            {
                app.LogInUser();
            }
            DriverUtilities.Wait(driver, 10);
            driver.FindElement(By.Id("loadingContainer")).Click();
            driver.FindElement(By.XPath("//*[@id='left-panel']/nav/ul/li[3]/a")).Click();
        }

        /// <summary>
        /// Selects `name` from App Rec School Search dropdown box
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="name"></param>
        public static void SelectSearch(IWebDriver driver, string name)
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

            driver.FindElement(By.Id("selectSearchObject")).Click();
            driver.FindElement(By.XPath("//option[@value='" + value + "']")).Click();
        }
    }
}
