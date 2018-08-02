/// <summary>
/// MemberListTestScripts.cs - Runs the tests from MemberList.cs
/// </summary>

using System;
using NUnit.Framework;
using OpenQA.Selenium;

namespace TCCApplication.TestScripts
{
    public class MemberListTestScript
    {
        private IWebDriver _driver;
        private Result _results;
        private MemberList _memberList;

        private const uint NumAccordions = 11;

        public MemberListTestScript(IWebDriver driver)
        {
            this._driver = driver;
            this._results = new Result();
            this._memberList = new MemberList(_driver);
        }

        /// <summary>
        /// Run all tests associated with the MemberList class.
        /// </summary>
        public void Run()
        {
            // Create test result file
            _results.CreateResultFile("MemberListTestInput");
            _results.WriteMainHeading("Testing Accordion Buttons");

            // Start timer
            DateTime startTime = DateTime.Now;

            // Verify NumAccordion buttons were clicked
            uint rv = _memberList.MemberSearch("Siena");
            Assert.AreEqual(rv, NumAccordions);

            // Stop timer
            DateTime stopTime = DateTime.Now;
            TimeSpan duration = stopTime - startTime;
            _results.TotalExecutionTime(duration);

            // Write results to file
            _results.WriteTestResults("Member_List", 1, 1);
        }
    }
}