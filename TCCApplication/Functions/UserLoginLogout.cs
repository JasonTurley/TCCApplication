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
        private Navigation _navigation;
        private DriverUtilitiesValidation _utilsValidation;
        private PageValidation _pageValidation;

        private bool SignedIn;

        public UserLoginLogout(IWebDriver driver)
        {
            this._driver = driver;
            this._userData = new UserData();
            this._navigation = new Navigation(_driver);
            this._utilsValidation = new DriverUtilitiesValidation(_driver);
            this._pageValidation = new PageValidation(_driver);
        }

        /// <summary>
        /// Logs into my TCC account
        /// </summary>
        public void LoginUser()
        {
            _navigation.NavigateToLoginPage(_driver);
            ApplicantCredentials(string.Empty, string.Empty);
        }


        /// <summary>
        /// Logs into my TCC account
        /// </summary>
        /// <param name="userEmail"></param>
        /// <param name="userPassword"></param>
        public void LoginUser(string userEmail, string userPassword)
        {
            _navigation.NavigateToLoginPage(_driver);
            ApplicantCredentials(userEmail, userPassword);
        }

        /// <summary>
        /// Logs user out of TCC
        /// </summary>
        public void LogoutUser()
        {
            this.SignedIn = false;
            _utilsValidation.Click(DriverUtilities.ElementAccessorType.ID, "loadingContainer");
            _utilsValidation.Click(DriverUtilities.ElementAccessorType.ID, "logoutLink");
        }

        /// <summary>
        /// Enters the provided email and password into the login field.
        /// If no email and password is provided, user default (my) info.
        /// </summary>
        /// <param name="userEmail"></param>
        /// <param name="userPassword"></param>
        public void ApplicantCredentials(string userEmail, string userPassword)
        {
            if (userEmail == string.Empty)
                userEmail = _userData.GetEmail(); 
            if (userPassword == string.Empty)
                userPassword = _userData.GetPassword(); 

            _utilsValidation.EnterText(DriverUtilities.ElementAccessorType.ID, "Username", userEmail);
            _utilsValidation.EnterText(DriverUtilities.ElementAccessorType.ID, "Password", userPassword);
            _utilsValidation.Click(DriverUtilities.ElementAccessorType.ClassName, "btn-primary");
            this.SignedIn = true;
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
