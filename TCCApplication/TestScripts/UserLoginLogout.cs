using System;
using OpenQA.Selenium;
using TCCApplication;
using TCCApplication.Data;

namespace TCCApplication
{
    public class UserLoginLogout
    {
        private IWebDriver _driver;
        private UserData _user;
        private Navigation _nav;
        private DriverUtilities _utils;

        public UserLoginLogout(IWebDriver driver)
        {
            this._driver = driver;
            this._user = new UserData();
            this._nav = new Navigation(_driver);
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
            _utils.Wait(_driver, 10);
            _utils.Click(DriverUtilities.ElementAccessorType.ID, "logoutLink");
        }

        /// <summary>
        /// Enters the provided email and password into the login field.
        /// If no email and password is provided, user default (my) info.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        public void ApplicantCredentials(string email, string password)
        {
            if (email == string.Empty) { email = _user.GetEmail(); }
            if (password == string.Empty) { password = _user.GetPassword(); }

            _utils.EnterText(DriverUtilities.ElementAccessorType.ID, "Username", email);
            _utils.EnterText(DriverUtilities.ElementAccessorType.ID, "Password", password);
            _utils.Click(DriverUtilities.ElementAccessorType.ClassName, "btn-primary");
        }
    }
}
