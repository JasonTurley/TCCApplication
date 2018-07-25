using System;
<<<<<<< HEAD
=======
using System.Timers;
>>>>>>> refactor
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
<<<<<<< HEAD
        /// Test that user can log in to TCC.
=======
        /// Test all the scripts in TestScripts/LoginLogoutTestScript.cs
>>>>>>> refactor
        /// </summary>
        [Test]
        public void TestLoginLogoutFunctions()
        {
<<<<<<< HEAD
            AppLoginLogout appLoginLogout = new AppLoginLogout(_driver);
            appLoginLogout.LogInUser();
            Assert.AreEqual(Pages.MemberListPage, _driver.Url); // Expected to be directed to member page
        }

        /// <summary>
        /// Test that provided user can log in to TCC.
=======
            LoginLogoutTestScript test = new LoginLogoutTestScript(_driver);
            test.UserLoginLogoutTestInput();
        }

        /// <summary>
        /// Test all the scripts in TestScripts/SearchForTestScript.cs
>>>>>>> refactor
        /// </summary>
        [Test]
        public void TestSearchForFunctions()
        {
<<<<<<< HEAD
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
=======
            SearchForTestScript test = new SearchForTestScript(_driver);
            test.SearchForTestInput();
        }    
>>>>>>> refactor

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