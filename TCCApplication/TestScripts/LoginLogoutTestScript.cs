using System;
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

        private const uint TotalTests = 3;

        public LoginLogoutTestScript(IWebDriver driver)
        {
            this._driver = driver;
            this._userLoginLogout = new UserLoginLogout(_driver);
            this._driverUtils = new DriverUtilities(_driver);
            this._pageValidation = new PageValidation(_driver);
        }

        /// <summary>
        /// Run all tests associated with the UserLoginLogout class.
        /// </summary>
        public void Run()
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