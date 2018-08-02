/// <summary>
/// MemberList.cs - Enables users to search for colleges on TCC's Member List page:w
/// </summary>

using System;
using OpenQA.Selenium;
using TCCApplication.Data;
using TCCApplication.Utilities;
using NUnit.Framework;

namespace TCCApplication
{
    public class MemberList
    {
        private IWebDriver _driver;
        private Navigation _navigation;
        private UserLoginLogout _userLoginLogout;
        private DriverUtilitiesValidation _utilsValidation;
        private UserData _userData;

        private string[] AccoridionIDs;

        public MemberList(IWebDriver driver)
        {
            this._driver = driver;
            this._navigation = new Navigation(_driver);
            this._userLoginLogout = new UserLoginLogout(_driver);
            this._utilsValidation = new DriverUtilitiesValidation(_driver);
            this._userData = new UserData();

            AccoridionIDs = new string[]
            {
                "abasicConfig",
                "ainformationDetails",
                "aQuesSupp",
                "testReq",
                "aPaymentReq",
                "aSupReq",
                "aRecReq",
                "aCutOffConfig",
                "aSDSConfiguration",
                "aFinAidConfig",
                "aDynamicText"
            };
        }

        /// <summary>
        /// Search for a member from the Member List page.
        /// </summary>
        /// <param name="name">Target member to search for</param>
        public void MemberSearch(string name)
        {
            _userLoginLogout.LoginUser(_userData.GetEmail(), _userData.GetPassword());

            // Enter member name into search box
            _utilsValidation.EnterText(DriverUtilities.ElementAccessorType.ID, "member-list-filter", name + Keys.Enter);
            _utilsValidation.ExplicitWait(DriverUtilities.ElementAccessorType.XPath, "//*[@data-bind='text: Name']", 10);

            // Click result link
            _utilsValidation.Click(DriverUtilities.ElementAccessorType.XPath, "//*[@data-bind='text: Name']");
        }

        /// <summary>
        /// Clicks all accordion menus lists on a member's page 
        /// </summary>
        public uint CountClickableAccordions()
        {
            uint totalClicked = 0;

            foreach (string id in AccoridionIDs)
            {
                _utilsValidation.Click(DriverUtilities.ElementAccessorType.ID, id);
                totalClicked++;
            }

            return totalClicked;
        }

    }
}
