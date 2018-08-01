using System;
using TCCApplication.Data;
using OpenQA.Selenium;

namespace TCCApplication.TestScripts
{
    public class SearchForTestScript
    {
        private IWebDriver _driver;
        private Result _results = new Result();

        private SearchFor _searchFor;
        private PageValidation _pageValidation;
        private UserData _userData;
        private RecommenderData _recData;
        private SchoolData _schoolData;
        private UserLoginLogout _userLoginLogout;

        private const uint TotalTests = 10;

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

        /// <summary>
        /// Run all tests associted with the SearchFor class.
        /// </summary>
        public void Run()
        {
            // Create test result file
            Result.CreateResultFile("SearchForTestInput");
            _results.WriteMainHeading("Searching For...");

            // Start timer
            DateTime startTime = DateTime.Now;

            // Test member search passed
            _searchFor.SearchForSchool("member", "", "Boston", "", "");
            _pageValidation.VerifyTargetIsPresent();

            // Test member search failed
            _searchFor.SearchForSchool("member", "", "UIUC", "", "");
            _pageValidation.VerifyTargetIsNotPresent();  // Check that table does NOT load

            // Test applicant search passed
            _searchFor.SearchForPerson("applicant", _userData.GetEmail(), _userData.GetFirstName(), _userData.GetLastName(), _userData.GetID(),
                                        _userData.GetPostalCode(), _userData.GetCEEBCode());
            _pageValidation.VerifyTargetIsPresent();

            // Test applicant search failed
            _searchFor.SearchForPerson("applicant", "invalid-email", "fname", "lname", "12345", "60111", "54321");
            _pageValidation.VerifyTargetIsNotPresent();

            // Test recommender search passed
            _searchFor.SearchForPerson("rec", _recData.GetEmail(), _recData.GetFirstName(), _recData.GetLastName(), _recData.GetID(), "", "");
            _pageValidation.VerifyTargetIsPresent();

            // Test recommender search failed
            _searchFor.SearchForPerson("recommender", "invalid-email", "fname", "lname", "12345", "60111", "54321");
            _pageValidation.VerifyTargetIsNotPresent();

            // Test high school search passed
            _searchFor.SearchForSchool("High school", _schoolData.GetCEEBCode(), _schoolData.GetName(), _schoolData.GetCity(), _schoolData.GetState());
            _pageValidation.VerifyTargetIsPresent();

            // Test high school search failed
            _searchFor.SearchForSchool("High school", "12345", _schoolData.GetName(), _schoolData.GetCity(), _schoolData.GetState());
            _pageValidation.VerifyTargetIsNotPresent();

            // Test college search passed
            _searchFor.SearchForSchool("college", _schoolData.GetCEEBCode(), _schoolData.GetName(), _schoolData.GetCity(), _schoolData.GetState());
            _pageValidation.VerifyTargetIsPresent();

            // Test college search failed
            _searchFor.SearchForSchool("colleges", "54321", _schoolData.GetName(), _schoolData.GetCity(), _schoolData.GetState());
            _pageValidation.VerifyTargetIsNotPresent();

            // Stop timer
            DateTime stopTime = DateTime.Now;
            TimeSpan duration = stopTime - startTime;
            _results.TotalExecutionTime(duration);

            // Output results
            _results.WriteTestResults("Search_For", _results.GetAmountPassed(), TotalTests);
            _results.ResetAmountPassed();
        }
    }
}
