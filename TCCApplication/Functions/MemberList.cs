/*
 * MemberList - class that enables user to search for Members.
 */

using System;
using OpenQA.Selenium;
using TCCApplication.Data;
using TCCApplication.Utilities;

namespace TCCApplication
{
    public class MemberList
    {
        private IWebDriver _driver;
        private Navigation _navigation;
        private UserLoginLogout _userLoginLogout;
        private DriverUtilities _driverUtils;
        private DriverUtilitiesValidation _utilsValidation;

        public MemberList(IWebDriver driver)
        {
            this._driver = driver;
            this._navigation = new Navigation(_driver);
            this._userLoginLogout = new UserLoginLogout(_driver);
            this._driverUtils = new DriverUtilities(_driver);
            this._utilsValidation = new DriverUtilitiesValidation(_driver);
        }

        /*
         * TODO:
         * - login to tcc (land on member list page)
         * - enter member in search box
         * - click result, if any
         * - collapse and expand accordions
         */

        public void MemberSearch(string name)
        {
            _userLoginLogout.LoginUser();
            _driverUtils.EnterText(DriverUtilities.ElementAccessorType.ID, "member-list-filter", name);

        }
    }
}
