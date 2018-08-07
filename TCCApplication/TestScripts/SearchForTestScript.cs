/// <summary>
/// SearchForTestScripts.cs - Runs the tests from SearchFor.cs
/// </summary>
using System;
using TCCApplication.Data;
using TCCApplication.Utilities;
using OpenQA.Selenium;

namespace TCCApplication.TestScripts
{
    public class SearchForTestScript
    {
        private IWebDriver _driver;
        private Result _results;
        private SearchFor _searchFor;
        private PageValidation _pageValidation;
        private DriverUtilitiesValidation _utilsValidation;
        private UserData _userData;
        private RecommenderData _recData;
        private SchoolData _schoolData;

        private const uint NumTests = 10;
        private uint AmountPassed = 0;

        public SearchForTestScript(IWebDriver driver)
        {
            this._driver = driver;
            this._results = new Result();
            this._searchFor = new SearchFor(_driver);
            this._pageValidation = new PageValidation(_driver);
            this._utilsValidation = new DriverUtilitiesValidation(_driver);
            this._userData = new UserData();
            this._recData = new RecommenderData();
            this._schoolData = new SchoolData();
        }

        /// <summary>
        /// Run all tests associted with the SearchFor class.
        /// </summary>
        public void Run()
        {
            // Create test result file
            _results.CreateResultFile("SearchForTestInput");
            _results.WriteMainHeading("Searching For...");

            // Start timer
            DateTime startTime = DateTime.Now;

            VerifyTestsPass();
            VerifyTestsFail();

            // Stop timer
            DateTime stopTime = DateTime.Now;
            TimeSpan duration = stopTime - startTime;
            _results.TotalExecutionTime(duration);

            // Output results
            _results.WriteTestResults("Search_For", AmountPassed, NumTests);
        }

        /// <summary>
        /// Runs all tests that are expected to pass
        /// </summary>
        private void VerifyTestsPass()
        {
            // Test applicant search passed
            _searchFor.SearchForPerson("applicant", _userData.GetEmail(), _userData.GetFirstName(), _userData.GetLastName(), _userData.GetID(),
                                        _userData.GetPostalCode(), _userData.GetCEEBCode());
            _pageValidation.VerifyResultsAreFound();
            AmountPassed++;

            // Test recommender search passed
            _searchFor.SearchForPerson("rec", _recData.GetEmail(), _recData.GetFirstName(), _recData.GetLastName(), _recData.GetID(), "", "");
            _pageValidation.VerifyResultsAreFound();
            AmountPassed++;

            // Test high school search passed
            _searchFor.SearchForSchool("High school", _schoolData.GetCEEBCode(), _schoolData.GetName(), _schoolData.GetCity(), _schoolData.GetState());
            _pageValidation.VerifyResultsAreFound();
            AmountPassed++;

            // Test college search passed
            _searchFor.SearchForSchool("college", _schoolData.GetCEEBCode(), _schoolData.GetName(), _schoolData.GetCity(), _schoolData.GetState());
            _pageValidation.VerifyResultsAreFound();
            AmountPassed++;
        }

        /// <summary>
        /// Runs all tests that are expected to fail
        /// </summary>
        private void VerifyTestsFail()
        {
            // Test applicant search failed
            _searchFor.SearchForPerson("applicant", "invalid-email", "fname", "lname", "12345", "60111", "54321");
            _pageValidation.VerifyNoResultsFound();
            AmountPassed++;

            // Test recommender search failed
            _searchFor.SearchForPerson("recommender", "invalid-email", "fname", "lname", "12345", "60111", "54321");
            _pageValidation.VerifyNoResultsFound();
            AmountPassed++;

            // Test high school search failed
            _searchFor.SearchForSchool("High school", "12345", _schoolData.GetName(), _schoolData.GetCity(), _schoolData.GetState());
            _pageValidation.VerifyNoResultsFound();
            AmountPassed++;

            // Test college search failed
            _searchFor.SearchForSchool("colleges", "54321", _schoolData.GetName(), _schoolData.GetCity(), _schoolData.GetState());
            _pageValidation.VerifyNoResultsFound();
            AmountPassed++;
        }
    }
}