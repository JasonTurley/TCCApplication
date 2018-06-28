using System;
using System.Timers;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using TCCApplication;
using TCCApplication.Data;
using TCCApplication.Utilities;
using TCCApplication.TestScripts;

namespace SmokeTest
{
    public class SmokeTestExecution
    {
        private IWebDriver _driver;
        private DriverUtilities _driverUtils;

        /// <summary>
        /// Set up Firefox browser, implicit wait time, and set the current directory
        /// </summary>
        [OneTimeSetUp]
        public void SetUp()
        {
            _driver = new FirefoxDriver();
            _driverUtils = new DriverUtilities(_driver);
            _driverUtils.ImplicitWait(10);
            System.IO.Directory.SetCurrentDirectory(TestContext.CurrentContext.WorkDirectory);
        }

        /// <summary>
        /// Test all the scripts in TestScripts/LoginLogoutTestScript.cs
        /// </summary>
        [Test]
        public void TestLoginLogoutFunctions()
        {
            LoginLogoutTestScript test = new LoginLogoutTestScript(_driver);
            test.UserLoginLogoutTestInput();
        }

        /// <summary>
        /// Test all the scripts in TestScripts/SearchForTestScript.cs
        /// </summary>
        [Test]
        public void TestSearchForFunctions()
        {
            SearchForTestScript test = new SearchForTestScript(_driver);
            test.SearchForTestInput();
        }    

        /// <summary>
        /// Cleanup resources
        /// </summary>
        [OneTimeTearDown]
        public void TearDown()
        {
            _driver.Close();
            _driver.Dispose();
        }
    }
}