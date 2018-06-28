using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TCCApplication;
using TCCApplication.Utilities;
using OpenQA.Selenium;

namespace TCCApplication.TestScripts
{
    public class SearchForTestScript
    {
        private IWebDriver _driver;
        private SearchFor _searchFor;
        private PageValidation _pageValidation;
        private UserLoginLogout _userLoginLogout;

        public SearchForTestScript(IWebDriver driver)
        {
            this._driver = driver;
            this._searchFor = new SearchFor(_driver);
            this._pageValidation = new PageValidation(_driver);
            this._userLoginLogout = new UserLoginLogout(_driver);
        }

        public void SearchForTestInput()
        {
            // Test member search passed
            _searchFor.SearchForSchool("member", "", "Boston", "", "");
            _pageValidation.VerifyTableIsPresent();

            // Test member search failed
            _searchFor.SearchForSchool("member", "", "UIUC", "", "");
            _pageValidation.VerifyTableIsNotPresent();  // Check that table does NOT load

            // Test applicant search failed
            _searchFor.SearchForPerson("applicant", "invalid-email", "fname", "lname", "12345", "60111", "54321");
            _pageValidation.VerifyTableIsNotPresent();

            // Test recommender search

            // Test high school search

            // Test college search
        }

        public void ResetTCC()
        {
            _userLoginLogout.LogoutUser();
        }
    }
}
