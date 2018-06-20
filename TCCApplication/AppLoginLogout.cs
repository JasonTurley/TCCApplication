using System;
using OpenQA.Selenium;
using TCCApplication.Data;

namespace TCCApplication
{
    public class AppLoginLogout
    {
        private IWebDriver _driver;
        private UserData _user;

        private bool LoggedIn { get; set; }


        public AppLoginLogout(IWebDriver driver)
        {
            this._driver = driver;
            this._user = new UserData();
        }

        /// <summary>
        /// Logs into my TCC account
        /// </summary>
        public void LogInUser()
        {
            Navigate.NavigateToLoginPage(_driver);
            ApplicantCredentials(string.Empty, string.Empty);
            this.LoggedIn = true;
        }

        /// <summary>
        /// Logs into TCC with the provided email and password
        /// </summary>
        /// <param name="userEmail"></param>
        /// <param name="userPassword"></param>
        public void LoginUserWithCredentials(string userEmail, string userPassword)
        {
            Navigate.NavigateToLoginPage(_driver);
            ApplicantCredentials(userEmail, userPassword);
        }

        /// <summary>
        /// Logs a user out of TCC
        /// </summary>
        public void LogOutUser()
        {
            // Click on the sign out button
            _driver.FindElement(By.Id("logoutLink")).Click();
        }

        /// <summary>
        /// Enters the provided email and password into the login field.
        /// If no email and password is provided, user default (my) info
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

        /// <summary>
        /// Check if user is already logged in
        /// </summary>
        /// <returns></returns>
        public bool IsLoggedIn()
        {
            return this.LoggedIn;
        }
    }
}
