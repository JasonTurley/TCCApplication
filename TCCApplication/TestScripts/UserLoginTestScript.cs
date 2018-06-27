using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using TCCApplication.Utilities;

namespace TCCApplication.TestScripts
{
    public class UserLoginTestScript
    {
        private IWebDriver _driver;
        private UserLoginLogout _userLoginLogout;
        private DriverUtilities _driverUtils;
        private PageValidation _pageValidation;

        public UserLoginTestScript(IWebDriver driver)
        {
            this._driver = driver;
            this._userLoginLogout = new UserLoginLogout(_driver);
            this._driverUtils = new DriverUtilities(_driver);
            this._pageValidation = new PageValidation(_driver);
        }

        /// <summary>
        /// Test that user can log in and out of TCC
        /// </summary>
        public void UserLoginTestInput()
        {
            // Test login pass
            _userLoginLogout.LoginUser();
            _driverUtils.ImplicitWait(30);
            _pageValidation.VerifyLoginPassed();

            // Test login fail
            _userLoginLogout.LoginUser();
            _driverUtils.ImplicitWait(30);
            _pageValidation.VerifyLoginFailed();

            // Test logout pass
            _userLoginLogout.LoginUser();
            _userLoginLogout.LogoutUser();
            _driverUtils.ImplicitWait(30);
            _pageValidation.VerifyLogoutPassed();

            // Test logout fail
            _userLoginLogout.LoginUser();
            _userLoginLogout.LogoutUser();
            _driverUtils.ImplicitWait(30);
            _pageValidation.VerifyLogoutFailed();
        }
    }
}
