using System;
using System.Timers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using TCCApplication;
using TCCApplication.Data;

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
            AppLoginLogout appLoginLogout = new AppLoginLogout(_driver);
            appLoginLogout.LogInUser();
            Assert.AreEqual(Pages.MemberListPage, _driver.Url); // Expected to be directed to member page
        }

        [Test]
        public void TestLoginUserWithCredentials()
        {
            AppLoginLogout appLoginLogout = new AppLoginLogout(_driver);
            appLoginLogout.LoginUserWithCredentials("User-Email", "User-Password");
            Assert.AreEqual(Pages.MainPage, _driver.Url);   // Expected to stay on main page since login will fail
        }

        [Test]
        public void TestLogOutUser()
        {
            AppLoginLogout appLoginLogout = new AppLoginLogout(_driver);
            appLoginLogout.LogInUser();                     // First, sign in the applicant
            appLoginLogout.LogOutUser();                    // Then sign them out
            Assert.AreEqual(Pages.MainPage, _driver.Url);   // Expected to be directed to main page
        }

        [Test]
        public void TestSearchForApplicant()
        {
            AppSearch appSearch = new AppSearch(_driver);
            appSearch.SearchForApplicant();
            //Assert.AreEqual(Pages.JasonTurleyAppProfile, _driver.Url);
        }

        [Test]
        public void TestSearchForNonExistentApplicant()
        {
            AppSearch appSearch = new AppSearch(_driver);
            appSearch.SearchForApplicant("applicant-email@gmail.com", "App", "Lee-cant");
        }

        [Test]
        public void TestSearchForRecommender()
        {
            AppSearch appSearch = new AppSearch(_driver);
            appSearch.SearchForRecommender();
        }

        [Test]
        public void TestSearchForCollege()
        {
            AppSearch appSearch = new AppSearch(_driver);
            appSearch.SearchForCollege();
        }

        [Test]
        public void TestSearchForHighSchool()
        {
            AppSearch appSearch = new AppSearch(_driver);
            appSearch.SearchForHighSchool();
        }

        [Test]
        public void TestSearchForMembers()
        {
            AppSearch appSearch = new AppSearch(_driver);
            appSearch.SearchForMember("Test Member");
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _driver.Close();
            _driver.Dispose();
        }
    }
}