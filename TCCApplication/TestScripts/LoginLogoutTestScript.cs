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

        private const uint TotalTests = 3;

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

            // Test login pass
            TestLogInPassed();

            // Test login fail
            TestLogInFailed();

            // Test logout pass
            TestLogOutPassed();

            // TODO: Test logout fail

            // Stop timer
            DateTime stopTime = DateTime.Now;
            TimeSpan duration = stopTime - startTime;
            _results.TotalExecutionTime(duration);

            // Output results
            _results.WriteTestResults("Login_Logout_Test", _results.GetAmountPassed(), TotalTests);
            _results.ResetAmountPassed();
        }

        /// <summary>
        /// Test that user can log into TCC
        /// </summary>
        private void TestLogInPassed()
        {
            _userLoginLogout.LoginUser(_userData.GetEmail(), _userData.GetPassword());
            _pageValidation.VerifyLoginPassed();
        }

        /// <summary>
        /// Test that an invalid user cannot log into TCC
        /// </summary>
        private void TestLogInFailed()
        {
            _userLoginLogout.LoginUser("invalid-email", "invalid password");
            _pageValidation.VerifyAtLoginScreen();
        }

        /// <summary>
        /// Test that a user can log out of TCC
        /// </summary>
        private void TestLogOutPassed()
        {
            _userLoginLogout.LoginUser(_userData.GetEmail(), _userData.GetPassword());
            _userLoginLogout.LogoutUser();
            _pageValidation.VerifyAtLoginScreen();
        }
    }
}