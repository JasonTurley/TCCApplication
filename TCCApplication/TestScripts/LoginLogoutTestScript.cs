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
            Result.CreateResultFile("LoginLogoutTest");
            _results.WriteToFile("test message");

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

            // Test logout fail?
            
        }
    }
}
