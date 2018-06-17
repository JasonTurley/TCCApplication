using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace TCCApplication
{
    public class AppLoginLogout
    {
        private IWebDriver _driver;        

        public AppLoginLogout(IWebDriver driver)
        {
            this._driver = driver;
        }

        /// <summary>
        /// Logs into my TCC account
        /// </summary>
        public void LogInUser()
        {
            NavigateToLoginPage();
            ApplicantCredentials(string.Empty, string.Empty);
        }

        /// <summary>
        /// Logs into TCC with provided email and password
        /// </summary>
        /// <param name="userEmail"></param>
        /// <param name="userPassword"></param>
        public void LoginUserWithInfo(string userEmail, string userPassword)
        {
            NavigateToLoginPage();
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
        /// Navigate to TCC Login Page
        /// </summary>
        public void NavigateToLoginPage()
        {
            _driver.Navigate().GoToUrl(Pages.MainPage);    
        }

        /// <summary>
        /// Enters the provided email and password into the login field.
        /// If no email and password is provided, user default (my) info
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        public void ApplicantCredentials(string email, string password)
        {
            if (email == string.Empty && password == string.Empty)
            {
                // Log into my TCC acount
                _driver.FindElement(By.Id("Username")).SendKeys(UserData.Email);
                _driver.FindElement(By.Id("Password")).SendKeys(UserData.Password);
                _driver.FindElement(By.ClassName("btn-primary")).Click();
            }
            else
            {
                // Log into user's account
            }
        }
    }
}
