﻿/// <summary>
/// LoginLogoutTestScripts.cs - Runs the tests from UserLoginLogout.cs
/// </summary>
using System;
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
            string username = _userData.GetEmail();
            string password = _userData.GetPassword();

            // Create test result file
            _results.CreateResultFile("LoginLogoutTest");
            _results.WriteMainHeading("User Login & Logout Test");

            // Start timer
            DateTime startTime = DateTime.Now;

            // Test login pass
            _userLoginLogout.LoginUser(username, password);
            _pageValidation.VerifyLoginPassed();
            _userLoginLogout.LogoutUser();

            // Test login fail
            _userLoginLogout.LoginUser("invalid-email", "invalid password");
            _pageValidation.VerifyLoginFailed();

            // Test logout pass
            _userLoginLogout.LoginUser(username, password);
            _userLoginLogout.LogoutUser();
            _pageValidation.VerifyLogoutPassed();

            // TODO: Test logout fail

            // Stop timer
            DateTime stopTime = DateTime.Now;
            TimeSpan duration = stopTime - startTime;
            _results.TotalExecutionTime(duration);

            // Output results
            _results.WriteTestResults("Login_Logout_Test", _results.GetAmountPassed(), TotalTests);
            _results.ResetAmountPassed();
        }
    }
}