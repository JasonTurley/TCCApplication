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
            //_results.CreateResultFile("MemberListTestInput");
            //_results.WriteMainHeading("Testing Accordion Buttons");

            // Start timer
            DateTime startTime = DateTime.Now;

            VerifyTestsPass();
            VerifyTestsFail();

            // Stop timer
            DateTime stopTime = DateTime.Now;
            TimeSpan duration = stopTime - startTime;
            //_results.TotalExecutionTime(duration);

            // Write results to file
            //_results.WriteTestResults("Member_List", 1, 1);
        }

        /// <summary>
        /// Runs all tests that are expected to pass
        /// </summary>
        private void VerifyTestsPass()
        {
            // Search for valid member Alma
            _memberList.MemberSearch("Alma");
            _pageValidation.VerifyResultsAreFound();
            TestMemberAccordionsWork();

            // Search for valid member 

        }

        /// <summary>
        /// Runs all tests that are expected to fail
        /// </summary>
        private void VerifyTestsFail()
        {
            // Search for invalid member QWERTY
            _memberList.MemberSearch("QWERTY");
            _pageValidation.VerifyNoResultsFound();
        }

        private void TestMemberAccordionsWork()
        {
            uint expectedTotal = 11;
            uint actualTotal;

            //_memberList.MemberSearch("Siena");
            actualTotal = _memberList.CountClickableAccordions();
            Assert.AreEqual(expectedTotal, actualTotal); 
        }
    }
}