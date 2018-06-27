using System;
using System.Timers;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using TCCApplication;
using TCCApplication.Data;
using TCCApplication.Utilities;

namespace SmokeTest
{
    public class SmokeTestExecution
    {
        private IWebDriver _driver;
        private DriverUtilities _utils;

        [OneTimeSetUp]
        public void SetUp()
        {
            _driver = new FirefoxDriver();
            _utils = new DriverUtilities(_driver);
            System.IO.Directory.SetCurrentDirectory(TestContext.CurrentContext.WorkDirectory);
        }

        [Test]
        public void TestLogInUser()
        {
            UserLoginLogout appLoginLogout = new UserLoginLogout(_driver);
            appLoginLogout.LogInUser();
            _utils.ImplicitWait(30);   // Give page time to load
            Assert.AreEqual(PageLinks.MemberPage, _driver.Url); // remove once validation class is implemented
        }

        [Test]
        public void TestLoginUserWithCredentials()
        {
            UserLoginLogout appLoginLogout = new UserLoginLogout(_driver);
            appLoginLogout.LoginUserWithCredentials("email", "password");
            Assert.AreEqual(PageLinks.MainPage, _driver.Url);   // Expected to stay on main page since login fails
        }

        [Test]
        public void TestLogOutUser()
        {
            UserLoginLogout appLoginLogout = new UserLoginLogout(_driver);
            appLoginLogout.LogInUser();                     // First, sign in the applicant
            appLoginLogout.LogOutUser();
            Assert.AreEqual(PageLinks.MainPage, _driver.Url);
        }

        [Test]
        public void TestSearchForApplicant()
        {
            Search search = new Search(_driver);
            search.SearchForPerson("applicant", "", "Peter", "Parker", "", "", "");
        }

 
        [Test]
        public void TestSearchForMembers()
        {
            Search appSearch = new Search(_driver);
            appSearch.SearchForSchool("member", "", "Boston College", "", "");
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _driver.Close();
            _driver.Dispose();
        }
    }
}