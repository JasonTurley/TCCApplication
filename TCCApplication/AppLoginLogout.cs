using System;
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
        private DriverUtilities _utilities;

        public AppLoginLogout(IWebDriver driver)
        {
            this._driver = driver;
            this._user = new UserData();
            this._nav = new Navigate(_driver);
            this._utilities = new DriverUtilities(_driver);
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
            _driver.FindElement(By.Id("loadingContainer")).Click();
            _utilities.Wait(_driver, 10);
            _driver.FindElement(By.Id("logoutLink")).Click();       // Click the sign out button
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

            _driver.FindElement(By.Id("Username")).SendKeys(email);
            _driver.FindElement(By.Id("Password")).SendKeys(password);
            _driver.FindElement(By.ClassName("btn-primary")).Click();
        }
    }
}
