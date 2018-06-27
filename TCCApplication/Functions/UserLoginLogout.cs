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
        private Navigation _nav;
        private DriverUtilities _utils;
        private DriverUtilitiesValidation _utilsValidation;
        private PageValidation _pageValidation;

        private bool SignedIn;

        public UserLoginLogout(IWebDriver driver)
        {
            this._driver = driver;
            this._userData = new UserData();
            this._nav = new Navigation(_driver);
            this._utils = new DriverUtilities(_driver);
            this._utilsValidation = new DriverUtilitiesValidation(_driver);
            this._pageValidation = new PageValidation(_driver);
        }

        /// <summary>
        /// Logs into my TCC account
        /// </summary>
        public void LoginUser()
        {
            _nav.NavigateToLoginPage(_driver);
            ApplicantCredentials(string.Empty, string.Empty);
            _utils.ImplicitWait(30);
            _pageValidation.VerifyLoginPassed();
        }

        /// <summary>
        /// Logs into TCC with the provided email and password
        /// </summary>
        /// <param name="userEmail"></param>
        /// <param name="userPassword"></param>
        public void LoginUserWithCredentials(string userEmail, string userPassword)
        {
            this.SignedIn = true;
            _nav.NavigateToLoginPage(_driver);
            ApplicantCredentials(userEmail, userPassword);
            _utils.ImplicitWait(30);
            _pageValidation.VerifyLoginPassed();
        }

        /// <summary>
        /// Logs user out of TCC
        /// </summary>
        public void LogoutUser()
        {
            this.SignedIn = false;
            _utilsValidation.Click(DriverUtilities.ElementAccessorType.ID, "loadingContainer");
            _utils.ImplicitWait(30);
            _utilsValidation.Click(DriverUtilities.ElementAccessorType.ID, "logoutLink");
            _utils.ImplicitWait(30);
            _pageValidation.VerifyLogoutPassed();
        }

        /// <summary>
        /// Enters the provided email and password into the login field.
        /// If no email and password is provided, user default (my) info.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        public void ApplicantCredentials(string email, string password)
        {
            if (email == string.Empty) { email = _userData.GetEmail(); }
            if (password == string.Empty) { password = _userData.GetPassword(); }

            _utilsValidation.EnterText(DriverUtilities.ElementAccessorType.ID, "Username", email);
            _utilsValidation.EnterText(DriverUtilities.ElementAccessorType.ID, "Password", password);
            _utilsValidation.Click(DriverUtilities.ElementAccessorType.ClassName, "btn-primary");
        }

        /// <summary>
        /// Returns true if user is currently signed in
        /// </summary>
        /// <returns></returns>
        public bool IsSignedIn()
        {
            return this.SignedIn;
        }
    }
}
