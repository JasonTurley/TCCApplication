using System;
using NUnit.Framework;
using OpenQA.Selenium;

namespace TCCApplication.TestScripts
{
    public class MemberListTestScript
    {
        private IWebDriver _driver;
        private MemberList _memberList;

        private const uint NumAccordions = 11;

        public MemberListTestScript(IWebDriver driver)
        {
            this._driver = driver;
            this._memberList = new MemberList(_driver);
        }

        /// <summary>
        /// Run all tests associated with the MemberList class.
        /// </summary>
        public void Run()
        {
            // TODO: add result file, timer, num_tests...

            uint rv = _memberList.MemberSearch("Siena");
            Assert.AreEqual(rv, NumAccordions);
        }
    }
}
