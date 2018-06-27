using System;
using System.Threading;
using OpenQA.Selenium;
using TCCApplication;
using TCCApplication.Data;

namespace TCCApplication
{
    public class AppLoginLogout
    {
        private IWebDriver _driver;
        private UserData _user;
        private Navigate _nav;
        private DriverUtilities _utils;

        public AppLoginLogout(IWebDriver driver)
        {
            this._driver = driver;
            this._user = new UserData();
            this._nav = new Navigate(_driver);
            this._utils = new DriverUtilities(_driver);
        }

        /// <summary>
        /// Logs into my TCC account
        /// </summary>
        public void LogInUser()
        {
            _nav.NavigateToLoginPage(_driver);
            ApplicantCredentials(string.Empty, string.Empty);
        }

        /// <summary>
        /// Logs into TCC with the provided email and password
        /// </summary>
        /// <param name="userEmail"></param>
        /// <param name="userPassword"></param>
        public void LoginUserWithCredentials(string userEmail, string userPassword)
        {
            _nav.NavigateToLoginPage(_driver);
            ApplicantCredentials(userEmail, userPassword);
        }

        /// <summary>
        /// Logs user out of TCC
        /// </summary>
        public void LogOutUser()
        {
            _utils.Click(DriverUtilities.ElementAccessorType.ID, "loadingContainer");
            _utils.Click(DriverUtilities.ElementAccessorType.ID, "logoutLink");
        }

        /// <summary>
        /// Enters the provided email and password into the login field.
        /// If no email and password is provided, user default (my) info.
        /// </summary>
        /// <param name="userEmail"></param>
        /// <param name="userPassword"></param>
        public void ApplicantCredentials(string userEmail, string userPassword)
        {
            if (userEmail == string.Empty && userPassword == string.Empty)
            {
                userEmail = _user.GetEmail();
                userPassword = _user.GetPassword();
            }

            _utils.EnterText(DriverUtilities.ElementAccessorType.ID, "Username", userEmail);
            _utils.EnterText(DriverUtilities.ElementAccessorType.ID, "Password", userPassword);
            _utils.Click(DriverUtilities.ElementAccessorType.ClassName, "btn-primary");
        }
    }
}