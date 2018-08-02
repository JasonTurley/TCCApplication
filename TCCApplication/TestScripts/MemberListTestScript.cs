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
           // _results.CreateResultFile("MemberListTestInput");
            //_results.WriteMainHeading("Testing Accordion Buttons");

            // Start timer
            DateTime startTime = DateTime.Now;

            // Verify expected amount of accorion menus were clicked
            TestMemberAccordionsWork();

            Thread.Sleep(4000);

            // Verify that no results are found
            TestNoMemberFound();

            // Stop timer
            DateTime stopTime = DateTime.Now;
            TimeSpan duration = stopTime - startTime;
            //_results.TotalExecutionTime(duration);

            // Write results to file
            //_results.WriteTestResults("Member_List", 1, 1);
        }

        public void TestMemberAccordionsWork()
        {
            string name = "Siena";
            uint expectedTotal = 11;
            uint actualTotal;

            _memberList.MemberSearch(name);
            actualTotal = _memberList.CountClickableAccordions();
            Assert.AreEqual(actualTotal, expectedTotal); 
        }

        public void TestNoMemberFound()
        {
            _memberList.MemberSearch("QWERTY");
            string actualText = _utilsValidation.GetText(DriverUtilities.ElementAccessorType.ClassName, "dataTables_empty");
            Assert.AreEqual(actualText, "No matching records found.");
        }
    }
}