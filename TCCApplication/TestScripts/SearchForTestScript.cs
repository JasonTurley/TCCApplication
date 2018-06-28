using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TCCApplication;
using TCCApplication.Data;
using TCCApplication.Utilities;
using OpenQA.Selenium;

namespace TCCApplication.TestScripts
{
    public class SearchForTestScript
    {
        private IWebDriver _driver;
        private SearchFor _searchFor;
        private PageValidation _pageValidation;
        private UserData _userData;
        private RecommenderData _recData;
        private SchoolData _schoolData;
        private UserLoginLogout _userLoginLogout;

        public SearchForTestScript(IWebDriver driver)
        {
            this._driver = driver;
            this._searchFor = new SearchFor(_driver);
            this._pageValidation = new PageValidation(_driver);
            this._userData = new UserData();
            this._recData = new RecommenderData();
            this._schoolData = new SchoolData();
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

            // Test applicant search passed
            _searchFor.SearchForPerson("applicant", _userData.GetEmail(), _userData.GetFirstName(), _userData.GetLastName(), _userData.GetID(),
                                        _userData.GetPostalCode(), _userData.GetCEEBCode());
            _pageValidation.VerifyTableIsPresent();

            // Test applicant search failed
            _searchFor.SearchForPerson("applicant", "invalid-email", "fname", "lname", "12345", "60111", "54321");
            _pageValidation.VerifyTableIsNotPresent();

            // Test recommender search passed
            _searchFor.SearchForPerson("rec", _recData.GetEmail(), _recData.GetFirstName(), _recData.GetLastName(), _recData.GetID(), "", "");
            _pageValidation.VerifyTableIsPresent();

            // Test recommender search failed
            _searchFor.SearchForPerson("recommender", "invalid-email", "fname", "lname", "12345", "60111", "54321");
            _pageValidation.VerifyTableIsNotPresent();

            // Test high school search passed
            _searchFor.SearchForSchool("High school", _schoolData.GetCEEBCode(), _schoolData.GetName(), _schoolData.GetCity(), _schoolData.GetState());
            _pageValidation.VerifyTableIsPresent();

            // Test high school search failed
            _searchFor.SearchForSchool("High school", "12345", _schoolData.GetName(), _schoolData.GetCity(), _schoolData.GetState());
            _pageValidation.VerifyTableIsNotPresent();

            // Test college search passed
            _searchFor.SearchForSchool("college", _schoolData.GetCEEBCode(), _schoolData.GetName(), _schoolData.GetCity(), _schoolData.GetState());
            _pageValidation.VerifyTableIsPresent();

            // Test college search failed
            _searchFor.SearchForSchool("colleges", "54321", _schoolData.GetName(), _schoolData.GetCity(), _schoolData.GetState());
            _pageValidation.VerifyTableIsNotPresent();
        }
    }
}
