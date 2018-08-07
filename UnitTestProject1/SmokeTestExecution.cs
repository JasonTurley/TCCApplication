/// <summary>
/// SmokeTestExecution.cs - Driver program for all test execution
/// </summary>

using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using TCCApplication.Utilities;
using TCCApplication.TestScripts;

namespace SmokeTest
{
    public class SmokeTestExecution
    {
        private IWebDriver _driver;
        private DriverUtilitiesValidation _utilsValidation;

        /// <summary>
        /// Initialize driver
        /// </summary>
        [OneTimeSetUp]
        public void SetUp()
        {
            this._driver = new FirefoxDriver();
            this._utilsValidation = new DriverUtilitiesValidation(_driver);
            _utilsValidation.ImplicitWait(10);
            System.IO.Directory.SetCurrentDirectory(TestContext.CurrentContext.WorkDirectory);
        }

        /// <summary>
        /// Runs all scenarios in TestScripts/LoginLogoutTestScript.cs
        /// </summary>
        [Test]
        public void RunLoginLogoutTestScript()
        {
            LoginLogoutTestScript test = new LoginLogoutTestScript(_driver);
            test.Run();
        }

        /// <summary>
        /// Runs all scenarios in TestScripts/SearchForTestScript.cs
        /// </summary>
        [Test]
        public void RunSearchForTestScript()
        {
            SearchForTestScript test = new SearchForTestScript(_driver);
            test.Run();
        }
       

        /// <summary>
        /// Runs all scenarios in TestScripts/MemberListTestScript.cs
        /// </summary>
        [Test]
        public void RunMemberListTestScript()
        {
            MemberListTestScript test = new MemberListTestScript(_driver);
            test.Run();
        }

        /// <summary>
        /// Cleanup 
        /// </summary>
        [OneTimeTearDown]
        public void TearDown()
        {
            _driver.Close();
            _driver.Dispose();
        }
    }
}