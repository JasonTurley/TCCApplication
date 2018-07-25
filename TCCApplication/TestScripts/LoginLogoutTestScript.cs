using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using TCCApplication.Utilities;

namespace TCCApplication.TestScripts
{
    public class LoginLogoutTestScript
    {
        private IWebDriver _driver;
        private Result _results = new Result();

        private UserLoginLogout _userLoginLogout;
        private DriverUtilities _driverUtils;
        private PageValidation _pageValidation;

        private int TotalTests;

        public LoginLogoutTestScript(IWebDriver driver)
        {
            this._driver = driver;
            this._userLoginLogout = new UserLoginLogout(_driver);
            this._driverUtils = new DriverUtilities(_driver);
            this._pageValidation = new PageValidation(_driver);
        }

        /// <summary>
        /// Test that user can log in and out of TCC
        /// </summary>
        public void UserLoginLogoutTestInput()
        {
            // Create test result file
            Result.CreateResultFile("LoginLogoutTest");
            _results.WriteMainHeading("User Login & Logout Test");

            // Start timer
            DateTime startTime = DateTime.Now;

            // Test login pass
            _userLoginLogout.LoginUser();
            _pageValidation.VerifyLoginPassed();
            _userLoginLogout.LogoutUser();

            // Test login fail
            _userLoginLogout.LoginUser("invalid-email", "invalid password");
            _pageValidation.VerifyLoginFailed();

            // Test logout pass
            _userLoginLogout.LoginUser();
            _userLoginLogout.LogoutUser();
            _pageValidation.VerifyLogoutPassed();

            // Test logout fail

            // Update me as more test cases are added
            TotalTests = 3;

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
