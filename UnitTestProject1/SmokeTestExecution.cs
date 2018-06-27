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
            UserLoginLogout appLoginLogout = new UserLoginLogout(_driver);
            appLoginLogout.LogInUser();
            Assert.AreEqual(PageLinks.MemberListPage, _driver.Url);
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
            SearchFor appSearch = new SearchFor(_driver);
            appSearch.SearchForApplicant();
            //Assert.AreEqual(Pages.JasonTurleyAppProfile, _driver.Url);
        }

        [Test]
        public void TestSearchForNonExistentApplicant()
        {
            SearchFor appSearch = new SearchFor(_driver);
            appSearch.SearchForApplicant("goak@mailinator.com", "Gary", "Oak");
        }

        [Test]
        public void TestSearchForRecommender()
        {
            SearchFor appSearch = new SearchFor(_driver);
            appSearch.SearchForRecommender();
            //Console.ReadKey();
        }

        [Test]
        public void TestSearchForCollege()
        {
            SearchFor appSearch = new SearchFor(_driver);
            appSearch.SearchForCollege();
        }

        [Test]
        public void TestSearchForHighSchool()
        {
            SearchFor appSearch = new SearchFor(_driver);
            appSearch.SearchForHighSchool();
        }

        [Test]
        public void TestSearchForMembers()
        {
            SearchFor appSearch = new SearchFor(_driver);
            appSearch.SearchForMember("Test");
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _driver.Close();
            _driver.Dispose();
        }
    }
}