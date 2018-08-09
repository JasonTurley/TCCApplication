/// <summary>
/// MemberListTestScripts.cs - Runs the tests from MemberList.cs
/// </summary>

using System;
using System.Threading;
using TCCApplication.Utilities;
using OpenQA.Selenium;
using NUnit.Framework;

namespace TCCApplication.TestScripts
{
    public class MemberListTestScript
    {
        private IWebDriver _driver;
        private Result _results;
        private MemberList _memberList;
        private PageValidation _pageValidation;
        private DriverUtilitiesValidation _utilsValidation;

        private const uint NumTests = 5;
        private uint AmountPassed = 0;

        public MemberListTestScript(IWebDriver driver)
        {
            this._driver = driver;
            this._results = new Result();
            this._memberList = new MemberList(_driver);
            this._pageValidation = new PageValidation(_driver);
            this._utilsValidation = new DriverUtilitiesValidation(_driver);
        }

        /// <summary>
        /// Run all tests associated with the MemberList class.
        /// </summary>
        public void Run()
        {
            // Create test result file
            _results.CreateResultFile("MemberListTestInput");
            _results.WriteMainHeading("Testing Member Search Functionality...");

            // Start timer
            DateTime startTime = DateTime.Now;

            VerifyTestsPass();
            VerifyTestsFail();

            // Stop timer
            DateTime stopTime = DateTime.Now;
            TimeSpan duration = stopTime - startTime;
            _results.TotalExecutionTime(duration);

            // Write results to file
            _results.WriteTestResults("Member_List", AmountPassed, NumTests);
        }

        /// <summary>
        /// Runs all tests that are expected to pass
        /// </summary>
        private void VerifyTestsPass()
        {
            TestMember("Siena");
            TestMember("Alma");
        }

        /// <summary>
        /// Runs all tests that are expected to fail
        /// </summary>
        private void VerifyTestsFail()
        {
            // Search for invalid member QWERTY
            _memberList.MemberSearch("QWERTY");
            _pageValidation.VerifyNoResultsFound();
            AmountPassed++;
        }

        private void TestMember(string memberName)
        {
            // lookup the member
            _memberList.MemberSearch(memberName);
            _pageValidation.VerifyResultsAreFound();
            AmountPassed++;

            // verify that all their accordions are clickable
            TestMemberAccordionsWork();     
        }
        /// <summary>
        /// Tests that a members accordion buttons expand and collapse when clicked.
        /// Assumes that user is already on a valid member's page.
        /// </summary>
        private void TestMemberAccordionsWork()
        {
            uint expectedTotal = 11;
            uint actualTotal = _memberList.CountClickableAccordions();

            Assert.AreEqual(expectedTotal, actualTotal); 
            AmountPassed++;
        }
    }
}