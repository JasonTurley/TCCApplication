/// <summary>
/// LoginLogoutTestScripts.cs - Runs the tests from UserLoginLogout.cs
/// </summary>
using System;
using System.Threading;
using TCCApplication.Data;
using OpenQA.Selenium;

namespace TCCApplication.TestScripts
{
    public class LoginLogoutTestScript
    {
        private IWebDriver _driver;
        private Result _results;
        private UserData _userData;
        private UserLoginLogout _userLoginLogout;
        private PageValidation _pageValidation;

        private const uint NumTests = 3;
        private uint AmountPassed = 0;

        public LoginLogoutTestScript(IWebDriver driver)
        {
            this._driver = driver;
            this._results = new Result();
            this._userLoginLogout = new UserLoginLogout(_driver);
            this._pageValidation = new PageValidation(_driver);
            this._userData = new UserData();
        }

        /// <summary>
        /// Run all tests associated with the UserLoginLogout class.
        /// </summary>
        public void Run()
        {
            // Create test result file
            _results.CreateResultFile("LoginLogoutTest");
            _results.WriteMainHeading("User Login & Logout Test");

            // Start timer
            DateTime startTime = DateTime.Now;

            VerifyTestsPass();
            VerifyTestsFail();

            // Stop timer
            DateTime stopTime = DateTime.Now;
            TimeSpan duration = stopTime - startTime;
            _results.TotalExecutionTime(duration);

            // Output results
            _results.WriteTestResults("Login_Logout_Test", AmountPassed, NumTests);
        }

        /// <summary>
        /// Runs all tests that are expected to pass
        /// </summary>
        private void VerifyTestsPass()
        {
            // Test log in works
            _userLoginLogout.LoginUser(_userData.GetEmail(), _userData.GetPassword());
            _pageValidation.VerifyLoginPassed();
            AmountPassed++;

            // Test log out works
            _userLoginLogout.LoginUser(_userData.GetEmail(), _userData.GetPassword());
            _userLoginLogout.LogoutUser();
            _pageValidation.VerifyAtLoginScreen();
            AmountPassed++;
        }

        /// <summary>
        /// Runs all tests that are expected to fail
        /// </summary>
        private void VerifyTestsFail()
        {
            _userLoginLogout.LoginUser("invalid-email", "invalid password");
            _pageValidation.VerifyAtLoginScreen();
            AmountPassed++;
        }
    }
}