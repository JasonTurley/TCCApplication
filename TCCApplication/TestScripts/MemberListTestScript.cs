using System;
using OpenQA.Selenium;
using TCCApplication.Utilities;

namespace TCCApplication.TestScripts
{
    public class MemberListTestScript
    {
        private IWebDriver _driver;
        private UserLoginLogout _userLoginLogout;
        private DriverUtilities _driverUtils;

        public MemberListTestScript(IWebDriver driver)
        {
            this._driver = driver;
            this._userLoginLogout = new UserLoginLogout(_driver);
            this._driverUtils = new DriverUtilities(_driver);
        }

        /// <summary>
        /// Run all tests associated with the MemberList class.
        /// </summary>
        public void Run()
    }
}
