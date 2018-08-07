/// <summary>
/// UserLoginLogout.cs - Functions to log in and out of TCC.
/// </summary>
using System;
using OpenQA.Selenium;
using TCCApplication;
using TCCApplication.Data;
using TCCApplication.Utilities;

namespace TCCApplication
{
    public class UserLoginLogout
    {
        private IWebDriver _driver;
        private UserData _userData;
        private DriverUtilitiesValidation _utilsValidation;
        private PageValidation _pageValidation;

        public UserLoginLogout(IWebDriver driver)
        {
            this._driver = driver;
            this._utilsValidation = new DriverUtilitiesValidation(_driver);
            this._pageValidation = new PageValidation(_driver);
            this._userData = new UserData();
        }

        /// <summary>
        /// Logs into my TCC account
        /// </summary>
        public void LoginUser(string email, string password)
        {
            _driver.Navigate().GoToUrl(PageValidation.MainPage);
            _driver.Manage().Window.Maximize();

            _utilsValidation.EnterText(DriverUtilities.ElementAccessorType.ID, "Username", email);
            _utilsValidation.EnterText(DriverUtilities.ElementAccessorType.ID, "Password", password);
            _utilsValidation.Click(DriverUtilities.ElementAccessorType.ClassName, "btn-primary");
        }

        /// <summary>
        /// Logs user out of TCC
        /// </summary>
        public void LogoutUser()
        {
            _utilsValidation.Click(DriverUtilities.ElementAccessorType.ID, "loadingContainer");
            _utilsValidation.Click(DriverUtilities.ElementAccessorType.ID, "logoutLink");
        }

    }
}
