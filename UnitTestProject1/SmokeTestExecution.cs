using System;
using System.Threading;
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

        /// <summary>
        /// Test that user can log in to TCC.
        /// </summary>
        [Test]
        public void TestLogInUser()
        {
            AppLoginLogout appLoginLogout = new AppLoginLogout(_driver);
            appLoginLogout.LogInUser();
            Assert.AreEqual(Pages.MemberListPage, _driver.Url); // Expected to be directed to member page
        }

        /// <summary>
        /// Test that provided user can log in to TCC.
        /// </summary>
        [Test]
        public void TestLoginUserWithCredentials()
        {
            AppLoginLogout appLoginLogout = new AppLoginLogout(_driver);
            appLoginLogout.LoginUserWithCredentials("User-Email", "User-Password");
            Assert.AreEqual(Pages.MainPage, _driver.Url);   // Expected to stay on main page since login will fail
        }

        /// <summary>
        /// Test that user can log out of TCC.
        /// </summary>
        [Test]
        public void TestLogOutUser()
        {
            AppLoginLogout appLoginLogout = new AppLoginLogout(_driver);
            appLoginLogout.LogInUser();                     // First, sign in the applicant
            appLoginLogout.LogOutUser();                    // Then sign them out
            Assert.AreEqual(Pages.MainPage, _driver.Url);   // Expected to be directed to main page
        }

        /// <summary>
        /// Test that an applicant can be searched for.
        /// </summary>
        [Test]
        public void TestSearchForApplicant()
        {
            AppSearch appSearch = new AppSearch(_driver);
            appSearch.SearchForApplicant();
            //Assert.AreEqual(Pages.JasonTurleyAppProfile, _driver.Url);
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void TestSearchForNonExistentApplicant()
        {
            AppSearch appSearch = new AppSearch(_driver);
            appSearch.SearchForApplicant("applicant-email@gmail.com", "App", "Lee-cant");
        }


        /// <summary>
        /// Test that a recommender can be searched for.
        /// </summary>
        [Test]
        public void TestSearchForRecommender()
        {
            AppSearch appSearch = new AppSearch(_driver);
            appSearch.SearchForRecommender();
        }

        /// <summary>
        /// Test that a college can be searched for.
        /// </summary>
        [Test]
        public void TestSearchForCollege()
        {
            AppSearch appSearch = new AppSearch(_driver);
            appSearch.SearchForCollege();
        }

        /// <summary>
        /// Test that a high school can be searched for.
        /// </summary>
        [Test]
        public void TestSearchForHighSchool()
        {
            AppSearch appSearch = new AppSearch(_driver);
            appSearch.SearchForHighSchool();
        }

        /// <summary>
        /// Test that a member can be searched for.
        /// </summary>
        [Test]
        public void TestSearchForMember()
        {
            AppSearch appSearch = new AppSearch(_driver);
            appSearch.SearchForMember("Test Member");
        }

        /// <summary>
        /// Test that the filter option works.
        /// </summary>
        [Test]
        public void TestFilter()
        {
            AppSearch appSearch = new AppSearch(_driver);
            appSearch.SearchForApplicant("", "Bob");
            Thread.Sleep(10000);
            appSearch.Filter("56785");
        }

        /// <summary>
        /// Test that the clear search fields button works.
        /// </summary>
        [Test]
        public void TestClearSearch()
        {
            AppSearch appSearch = new AppSearch(_driver);
            appSearch.SearchForCollege("Martin Luther King", "Atlanta", "GA");
            appSearch.ClearSearch();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _driver.Close();
            _driver.Dispose(); 
        }
    }
}